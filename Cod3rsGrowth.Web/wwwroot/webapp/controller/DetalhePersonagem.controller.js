sap.ui.define([
	"coders-growth/common/BaseController",
	"coders-growth/common/HttpService",
	"coders-growth/common/Constantes",
    "sap/m/MessageBox",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat"
], function (BaseController, HttpService, Constantes, MessageBox, JSONModel, DateFormat) {
	"use strict";

	const ACAO_OK = "OK";

	return BaseController.extend("coders-growth.controller.DetalhePersonagem", {
		onInit: function () {
            this.__vincularRota(Constantes.ROTA_PERSONAGEM, this._aoCarregarDetalhes);
		},

		_carregarPersonagem: async function (id) {
			return await HttpService.get(Constantes.URL_PERSONAGEM, id);
		},

		_carregarHabilidadesDoPersonagem: async function (id) {
			return await HttpService.get(Constantes.URL_HABILIDADE, id);
		},

        _aoCarregarDetalhes: async function (evento) {

			const argumentos = evento.getParameter("arguments");
			try {
				const personagem = await this._carregarPersonagem(argumentos.idPersonagem);
				this.__definirModelo(new JSONModel(personagem), Constantes.MODELO_PERSONAGEM);
				const modeloPersonagem = this.__obterModelo(Constantes.MODELO_PERSONAGEM);

				const habilidadesDoPersonagem = await Promise.all(personagem.habilidades.map(async (id) => {
					return await this._carregarHabilidadesDoPersonagem(id);
				}));
				this.__definirModelo(new JSONModel(habilidadesDoPersonagem), Constantes.MODELO_HABILIDADES);

				var txtEVilao = this.__obterElementoPorId(Constantes.ID_TEXT_PROPOSITO);
				modeloPersonagem.getProperty(Constantes.PROPRIEDADE_E_VILAO) ? txtEVilao.addStyleClass(Constantes.CLASSE_VILAO).removeStyleClass(Constantes.CLASSE_HEROI) : txtEVilao.addStyleClass(Constantes.CLASSE_HEROI).removeStyleClass(Constantes.CLASSE_VILAO);
			}
			catch (erro) {
				console.log("aqui")
                this.__navegarPara(Constantes.ROTA_NOT_FOUND);
            }
		},

		aoClicarEmEditarPersonagem: function() {
			this.__navegarPara(Constantes.ROTA_EDITAR_PERSONAGEM, { idPersonagem: this.__obterModelo(Constantes.MODELO_PERSONAGEM).getData().id });
		},

		aoClicarEmRemoverPersonagem: async function () {
			MessageBox.warning(Constantes.MSG_AVISO_DE_EXCLUSAO, { 
				actions: [MessageBox.Action.OK, MessageBox.Action.CANCEL], 
				emphasizedAction: MessageBox.Action.OK,
				onClose: async (acao) => {
					if (acao === ACAO_OK) {	
						await HttpService.delete(Constantes.URL_PERSONAGEM, this.__obterModelo(Constantes.MODELO_PERSONAGEM).getData().id);
						this.__navegarPara(Constantes.ROTA_PERSONAGENS);
					}
				}
			});			
		},
		
		formatter: {	
            formatarNivel: function(valor) {
                switch (valor) {
					case 0: return Constantes.STATUS_FRACO;
					case 1: return Constantes.STATUS_MEDIO;
					case 2: return Constantes.STATUS_BOM;
					case 3: return Constantes.STATUS_EXCEPCIONAL;
					case 4: return Constantes.STATUS_EXTRAORDINARIO;
					default: return Constantes.STATUS_DESCONHECIDO;
				}
            },
			formatarProposito: function(proposito) {
                return proposito ? Constantes.PROPOSITO_VILAO : Constantes.PROPOSITO_HEROI;
            },
			formatarData: function(data) {
				if (!data) return "---";

				const formatadorDeData = DateFormat.getDateTimeInstance({ pattern: "dd/MM/yyyy" });
            	return formatadorDeData.format(new Date(data));
			}
        }
	});
});