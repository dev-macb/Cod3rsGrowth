sap.ui.define([
    "coders-growth/common/BaseController",
    "coders-growth/common/HttpService",
    "coders-growth/common/Constantes",
    "coders-growth/models/Formatador",
    "sap/ui/model/json/JSONModel"
], function (BaseController, HttpService, Constantes, Formatador, JSONModel) {
	"use strict";

    return BaseController.extend("coders-growth.controller.DetalheHabilidade", {
		formatter: Formatador,

        onInit: function () {
            this.__vincularRota(Constantes.ROTA_HABILIDADE, this._aoCoincidirRota);
        },

		_aoCoincidirRota: function (evento) {
			this.idHabilidade = evento.getParameter("arguments").idHabilidade;
			this._carregarDetalhesDaHabilidade();
		},

        _carregarDetalhesDaHabilidade: async function () {
			this.__exibirEspera(async () => {
				try {
					const habilidade = await HttpService.get(Constantes.URL_HABILIDADE, this.idHabilidade);
					this.__definirModelo(new JSONModel(habilidade), Constantes.MODELO_HABILIDADE);
				}
				catch {
					this.__navegarPara(Constantes.ROTA_NOT_FOUND);
				}
			});
		},

		aoClicarEmEditarHabilidade: function () {
			this.__navegarPara(Constantes.ROTA_EDITAR_HABILIDADE, { idHabilidade: this.idHabilidade });
		},

		aoClicarEmExcluirHabilidade: function () {
			this.__exibirEspera(async () => {
				this.__exibirMensagemDeConfirmacao(async () => {
					await HttpService.delete(Constantes.URL_HABILIDADE, this.idHabilidade);
					this.__exibirMessageToast(`Habilidade ${this.idHabilidade} foi excluída!`);
					this.__navegarPara(Constantes.ROTA_HABILIDADES);
				});
			});
		}
	});
});