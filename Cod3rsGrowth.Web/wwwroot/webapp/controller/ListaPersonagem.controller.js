sap.ui.define([
	"coders-growth/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (BaseController, JSONModel, Filter, FilterOperator) => {
	"use strict";

	return BaseController.extend("coders-growth.controller.ListaPersonagem", {
		onInit: function() {
            const urlObterTodosPersonagens = "https://localhost:5051/api/Personagem";
			
			fetch(urlObterTodosPersonagens, {
				method: "GET",
				headers: { "Content-Type": "application/json" },
			})
			.then(resposta => {
				if (resposta.ok) {
					return resposta.json();
				} 
				else {
					throw new Error('Erro na resposta da API');
				}
			})
			.then(personagens => {
				const modeloPersonagem = new JSONModel(personagens);
            	this.getView().setModel(modeloPersonagem);
			})
			.catch(erro => {
				console.error(erro);
			});
        },

		aoFiltrarPersonagemPorNome(evento) {
			const filtro = [];
			const sQuery = evento.getSource().getValue();
			if (sQuery && sQuery.length > 0) {
				filtro.push(new Filter("nome", FilterOperator.Contains, sQuery));
			}

			const oList = this.byId("listaPersonagem");
			const oBinding = oList.getBinding("items");
			oBinding.filter(filtro);
		}
	});
});
