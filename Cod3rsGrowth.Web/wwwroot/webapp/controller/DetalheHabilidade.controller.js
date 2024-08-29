sap.ui.define([
    "coders-growth/common/BaseController",
    "coders-growth/common/HttpService",
    "coders-growth/common/Constantes",
    "sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat"
], function (BaseController, HttpService, Constantes, JSONModel, DateFormat) {
	"use strict";

    return BaseController.extend("coders-growth.controller.DetalheHabilidade", {
        onInit: function () {
            this.__vincularRota(Constantes.ROTA_HABILIDADE, this._carregarDetalhes);
        },

        _carregarDetalhes: async function (evento) {
			this.__exibirEspera(async () => {
				const argumentos = evento.getParameter("arguments");

				try {
					const habilidade = await HttpService.get(Constantes.URL_HABILIDADE, argumentos.idHabilidade);
					this.__definirModelo(new JSONModel(habilidade), Constantes.MODELO_HABILIDADE);
				}
				catch (erro) {
					this.__navegarPara(Constantes.ROTA_NOT_FOUND);
				}
			});
		},

		formatter: {	
			formatarData: function(data) {
				if (!data) return "---";

				const formatadorDeData = DateFormat.getDateTimeInstance({ pattern: "dd/MM/yyyy" });
            	return formatadorDeData.format(new Date(data));
			}
        }
	});
});