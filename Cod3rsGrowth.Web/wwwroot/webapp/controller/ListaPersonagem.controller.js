sap.ui.define([
	"coders-growth/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (BaseController, JSONModel, Filter, FilterOperator) => {
	"use strict";

	return BaseController.extend("coders-growth.controller.ListaPersonagem", {
		onInit() {
			this._personagemModelo = new JSONModel({
				itens: [],
				paginaAtual: 1,
				itensPorPagina: 10,
				totalPaginas: 0
			});
			this.getView().setModel(this._personagemModelo, "paginacao");
			this._carregarDados();
        },

		_carregarDados() {
			try {
                const urlObterTodosPersonagens = "https://localhost:5051/api/Personagem";

                const resposta = await fetch(urlObterTodosPersonagens, {
                    method: "GET",
                    headers: { "Content-Type": "application/json" },
                });

                if (!resposta.ok) {
                    throw new Error('Erro na resposta da API');
                }

                const personagens = await resposta.json();
                this._oModel.setProperty("/items", personagens);
                this._updatePaginator();
                this._updateList();
            } catch (error) {
                console.error("Erro ao carregar dados:", error);
            }
		},

		_atualizarPaginacao() {
            const totalItems = this._personagemModelo.getProperty("/itens").length;
            const itemsPerPage = this._personagemModelo.getProperty("/itensPorPagina");
            const pageCount = Math.ceil(totalItems / itemsPerPage);

            this._personagemModelo.setProperty("/totalPaginas", pageCount);
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
		},

        async aoAbrirFiltros() {
            this.dialogoFiltros ??= await this.loadFragment({
                name: "coders-growth.view.ListaPersonagem"
            });
            this.dialogoFiltros.open();
        },

		aoAplicarFiltros() {
			this.byId("helloDialog").close();
		}
	});
});
