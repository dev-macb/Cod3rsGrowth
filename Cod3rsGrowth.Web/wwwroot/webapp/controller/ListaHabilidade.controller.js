sap.ui.define([
	"coders-growth/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], function(BaseController, JSONModel) {
	"use strict";

	return BaseController.extend("coders-growth.controller.ListaHabilidade", {
        onInit: function() {
			this._filtros = {};
            this._carregarHabilidades();
        },


        _carregarHabilidades: async function() {
            const urlObterTodasHabilidades = new URL("https://localhost:5051/api/Habilidade");

			Object.keys(this._filtros).forEach(chave => {
                urlObterTodasHabilidades.searchParams.append(chave, this._filtros[chave]);
            });

			try {
				const resposta = await fetch(urlObterTodasHabilidades, {
					method: "GET",
					headers: { "Content-Type": "application/json" },
				});
				
				if (!resposta.ok) throw new Error('Erro na resposta da API');

				const habilidades = await resposta.json();
				const modeloHabilidade = new JSONModel(habilidades);
				this.getView().setModel(modeloHabilidade);
				this.obterRotiador().navTo("habilidades", Object.keys(this._filtros).length === 0 ? {} : { "?query": this._filtros });
			} 
			catch (erro) {
				console.error(erro);
			}
        },

		
        aoFiltrarHabilidadePorNome: function(evento) {
			const filtroNome = evento.getSource().getValue();
			
			if (filtroNome) { this._filtros.nome = filtroNome; } 
			else { delete this._filtros.nome; }	

			this._carregarHabilidades();
		},
    });
});