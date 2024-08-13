sap.ui.define([
	"coders-growth/common/BaseController",
	"coders-growth/common/HttpService",
	"coders-growth/common/Constantes",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat"
], function (BaseController, HttpService, Constantes, JSONModel, DateFormat) {
	"use strict";

	const STATUS_FRACO = "Fraco";
	const STATUS_MEDIO = "Médio";
	const STATUS_BOM = "Bom";
	const STATUS_EXCEPCIONAL = "Excepcional";
	const STATUS_EXTRAORDINARIO = "Extraordinário";
	const STATUS_DESCONHECIDO = "Desconhecido";
	const PROPOSITO_VILAO = "Vilão";
	const PROPOSITO_HEROI = "Herói";
	const ROTA_PERSONAGEM = "personagem"; 
	const MODELO_PERSONAGEM = "personagem"; 
	const MODELO_HABILIDADES = "habilidades"; 
	const ID_TEXT_PROPOSITO = "txtEVilao";
	const CLASSE_VILAO = "txtVilao";
	const CLASSE_HEROI = "txtHeroi";
	const PROPRIEDADE_E_VILAO = "/eVilao";
	const ROTA_NOT_FOUND = "notFound";

	return BaseController.extend("coders-growth.controller.DetalhePersonagem", {
		onInit: function () {
            this.__vincularRota(ROTA_PERSONAGEM, this._aoCarregarDetalhes);
		},

        _aoCarregarDetalhes: async function (evento) {
			const argumentos = evento.getParameter("arguments");
			try {
				const personagem = await HttpService.get(Constantes.URL_PERSONAGEM, argumentos.idPersonagem); // PersonagemService.obterPorId(argumentos.idPersonagem);
				const modeloPersonagem = new JSONModel(personagem);
				this.__definirModelo(modeloPersonagem, MODELO_PERSONAGEM);

				const habilidades = await Promise.all(personagem.habilidades.map((id) => {
					return HttpService.get(Constantes.URL_HABILIDADE, id);
				}));
				this.__definirModelo(new JSONModel(habilidades), MODELO_HABILIDADES);

				var txtEVilao = this.byId(ID_TEXT_PROPOSITO);
				modeloPersonagem.getProperty(PROPRIEDADE_E_VILAO) ? txtEVilao.addStyleClass(CLASSE_VILAO).removeStyleClass(CLASSE_HEROI) : txtEVilao.addStyleClass(CLASSE_HEROI).removeStyleClass(CLASSE_VILAO)
			}
			catch (erro) {
                console.error("Erro ao obter detalhes do personagem:", erro);
                this.__obterRotiador().getTargets().display(ROTA_NOT_FOUND);
            }
		},

		formatter: {	
            formatarNivel: function(valor) {
                switch (valor) {
					case 0: return STATUS_FRACO;
					case 1: return STATUS_MEDIO;
					case 2: return STATUS_BOM;
					case 3: return STATUS_EXCEPCIONAL;
					case 4: return STATUS_EXTRAORDINARIO;
					default: return STATUS_DESCONHECIDO;
				}
            },
			formatarProposito: function(proposito) {
                return proposito ? PROPOSITO_VILAO : PROPOSITO_HEROI;
            },
			formatarData: function(data) {
				if (!data) return "---";

				const formatadorDeData = DateFormat.getDateTimeInstance({ pattern: "dd/MM/yyyy" });
            	return formatadorDeData.format(new Date(data));
			}
        }
	});
});