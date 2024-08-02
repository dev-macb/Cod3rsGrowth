sap.ui.define([
	"coders-growth/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"../services/PersonagemService",
	"../services/HabilidadeService",
], function (BaseController, JSONModel, PersonagemService, HabilidadeService) {
	"use strict";

	const STATUS_FRACO = "Fraco";
	const STATUS_MEDIO = "Médio";
	const STATUS_BOM = "Bom";
	const STATUS_EXCEPCIONAL = "Excepcional";
	const STATUS_EXTRAORDINARIO = "Extraordinário";
	const STATUS_DESCONHECIDO = "Desconhecido";
	const PROPOSITO_VILAO = "Vilão";
	const PROPOSITO_HEROI = "Herói";

	return BaseController.extend("coders-growth.controller.DetalhePersonagem", {
		onInit: function () {
            this.obterRotiador().getRoute("personagem").attachMatched(this._aoCarregarDetalhes, this);
		},

        _aoCarregarDetalhes: async function (evento) {
			const argumentos = evento.getParameter("arguments");
			try {
				const personagem = await PersonagemService.obterPorId(argumentos.idPersonagem);
				const modeloPersonagem = new JSONModel(personagem);
				this.getView().setModel(modeloPersonagem, "personagem");

				const habilidades = await HabilidadeService.obterHabilidadesPorIds(personagem.habilidades);
                const modeloHabilidades = new JSONModel(habilidades);
				this.getView().setModel(modeloHabilidades, "habilidades");

				var txtEVilao = this.byId('txtEVilao');
				modeloPersonagem.getProperty("/eVilao") ? txtEVilao.addStyleClass("txtVilao").removeStyleClass("txtHeroi") : txtEVilao.addStyleClass("txtHeroi").removeStyleClass("txtVilao")
			}
			catch (erro) {
                console.error("Erro ao obter detalhes do personagem:", erro);
                this.obterRotiador().getTargets().display("notFound");
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
            }
        }
	});
});