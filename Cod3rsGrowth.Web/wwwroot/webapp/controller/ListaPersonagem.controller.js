sap.ui.define([
	"coders-growth/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], function(BaseController, JSONModel, Filter, FilterOperator) {
	"use strict";

	return BaseController.extend("coders-growth.controller.ListaPersonagem", {
		onInit: function() {
			this._filtros = {};
            this._carregarPersonagens();
        },


		_carregarPersonagens: async function() {
			const urlObterTodosPersonagens = new URL("https://localhost:5051/api/Personagem");

			Object.keys(this._filtros).forEach(chave => {
                urlObterTodosPersonagens.searchParams.append(chave, this._filtros[chave]);
            });

			try {
				const resposta = await fetch(urlObterTodosPersonagens, {
					method: "GET",
					headers: { "Content-Type": "application/json" },
				});

				if (!resposta.ok) throw new Error('Erro na resposta da API');

				const personagens = await resposta.json();
				const modeloPersonagem = new JSONModel(personagens);
            	this.getView().setModel(modeloPersonagem);
			}
			catch (erro) {
				console.error(erro);
			}
		},


		aoFiltrarPersonagemPorNome(evento) {
			const filtros = [];
			const query = evento.getSource().getValue();
			
			if (query && query.length > 0) {
				filtros.push(new Filter("nome", FilterOperator.Contains, query));
			}

			const listaPersonagens = this.byId("listaPersonagem");
			const bindingPersonagens = listaPersonagens.getBinding("items");
			bindingPersonagens.filter(filtros);
		},


		aoAbrirFiltros: async function() {
			this.dialogoFiltros ??= await this.loadFragment({
				name: "coders-growth.view.ListaPersonagem",
				controller: this
			});
			this.dialogoFiltros.open();
		},


		aoAplicarFiltros: async function(evento) {
			const itensDoFiltro = evento.getParameter("filterItems");
			
			itensDoFiltro.forEach((item) => {
				switch(item.getKey()) {
					case "heroi":
						this._filtros.evilao = false;
						break;

					case "vilao":
						this._filtros.evilao = true;
						break;

					default:
						break;
				}
			});
			this._carregarPersonagens();
		},

		
		aoResetarFiltros: function() {
			this._filtros = {};
			this._carregarPersonagens();
		}
	});
});