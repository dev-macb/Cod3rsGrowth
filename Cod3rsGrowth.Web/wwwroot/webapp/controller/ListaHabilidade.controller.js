sap.ui.define([
	"coders-growth/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], function(BaseController, JSONModel, Filter, FilterOperator) {
	"use strict";

	return BaseController.extend("coders-growth.controller.ListaHabilidade", {
        onInit: function() {
            this._carregarHabilidades();
        },


        _carregarHabilidades: async function() {
            const urlObterTodasHabilidades = new URL("https://localhost:5051/api/Habilidade");

			try {
				const resposta = await fetch(urlObterTodasHabilidades, {
					method: "GET",
					headers: { "Content-Type": "application/json" },
				});
				
				if (!resposta.ok) throw new Error('Erro na resposta da API');

				const habilidades = await resposta.json();
				const modeloHabilidade = new JSONModel(habilidades);
				this.getView().setModel(modeloHabilidade);
			} 
			catch (erro) {
				console.error(erro);
			}
        },

		
        aoFiltrarHabilidadePorNome: function(evento) {
			const filtros = [];
			const query = evento.getSource().getValue();
			
			if (query && query.length > 0) {
				filtros.push(new Filter("nome", FilterOperator.Contains, query));
			}

			const listaHabilidades = this.byId("listaHabilidade");
			const bindingHabilidades = listaHabilidades.getBinding("items");
			bindingHabilidades.filter(filtros);
		},
    });
});