sap.ui.define([
	"coders-growth/controller/BaseController",
    "sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat"
], function(BaseController, JSONModel, DateFormat) {
	"use strict";

	return BaseController.extend("coders-growth.controller.ListaHabilidade", {
        onInit: function() {
			this._filtros = {};
            this._carregarHabilidades();
        },


        _carregarHabilidades: async function() {
			const urlObterTodasHabilidades = new URL("https://localhost:5051/api/Habilidade");
		
			Object.keys(this._filtros).forEach(chave => {
				let valor = this._filtros[chave];
		
				if (chave === "database" || chave === "datateto") {
					const data = new Date(valor);
					if (!isNaN(data)) valor = data.toISOString();
				}
				
				urlObterTodasHabilidades.searchParams.append(chave, valor);
			});
		
			try {
				console.log(urlObterTodasHabilidades.href)
				const resposta = await fetch(urlObterTodasHabilidades.href, {
					method: "GET",
					headers: { "Content-Type": "application/json" },
				});
		
				if (!resposta.ok) throw new Error('Erro na resposta da API');
		
				const habilidades = await resposta.json();
				const modeloHabilidade = new JSONModel(habilidades);
				this.getView().setModel(modeloHabilidade);
				this.obterRotiador().navTo("habilidades", Object.keys(this._filtros).length === 0 ? {} : { "?query": this._filtros });
			} catch (erro) {
				console.error(erro);
			}
		},

        aoFiltrarHabilidadePorNome: function(evento) {
			const filtroNome = evento.getSource().getValue();
			
			if (filtroNome) { this._filtros.nome = filtroNome; } 
			else { delete this._filtros.nome; }	

			this._carregarHabilidades();
		},

		aoAbrirFiltrosHabilidade: async function() {
			this.dialogoFiltrosHabilidade ??= await this.loadFragment({
				name: "coders-growth.view.FiltroHabilidade",
				controller: this
			});
			this.dialogoFiltrosHabilidade.open();
		},

		tratarSelecaoDeDatas: function (evento) {
			var calendario = evento.getSource();
			var datasSelecionadas = calendario.getSelectedDates()[0];
		
			if (datasSelecionadas) {
				var formatadorDeData = sap.ui.core.format.DateFormat.getDateTimeInstance({
					pattern: "yyyy-MM-dd'T'HH:mm:ss'Z'"
				});
				this._filtros.database = formatadorDeData.format(datasSelecionadas.getStartDate());
				this._filtros.datateto = formatadorDeData.format(datasSelecionadas.getEndDate());
			}
		},

		aoAplicarFiltrosHabilidade: async function(evento) {
			console.log('APLICAR FILTROS')
			this._carregarHabilidades();
		},

		
		aoResetarFiltrosHabilidade: function() {
			this._filtros = {};
			this.byId("calendario").removeAllSelectedDates();

			this._carregarHabilidades();
		},
    });
});