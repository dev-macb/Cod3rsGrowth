sap.ui.define([
	"coders-growth/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"../services/PersonagemService",
	"../services/HabilidadeService",
], function (BaseController, JSONModel, PersonagemService, HabilidadeService) {
	"use strict";

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
			}
			catch (erro) {
                console.error("Erro ao obter detalhes do personagem:", erro);
                this.obterRotiador().getTargets().display("notFound");
            }
		},

		formatter: {	
            formatarNivel: function(valor) {
                switch (valor) {
					case 0: return "Fraco";
					case 1: return "Médio";
					case 2: return "Bom";
					case 3: return "Excepcional";
					case 4: return "Extraordinário";
					default: return "Desconhecido";
				}
            },
			formatarProposito: function(proposito) {
                return proposito ? "Vilão" : "Herói";
            },
            definirClasseProposito: function(proposito) {
                return proposito ? "txtVilao" : "txtHeroi";
            }
        }
	});
});