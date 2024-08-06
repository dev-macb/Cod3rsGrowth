sap.ui.define([
	"coders-growth/controller/BaseController",
    "sap/ui/model/json/JSONModel",
	"../services/HabilidadeService"
], function(BaseController, JSONModel, HabilidadeService) {
	"use strict";

	const ROTA_HABILIDADES = "habilidades";
	const ID_CALENDARIO = "calendario";

	return BaseController.extend("coders-growth.controller.ListaHabilidade", {
        onInit: function() {
			this._filtros = {};
			this.vincularRota(ROTA_HABILIDADES, this._aoConcidirRota);
        },

		_aoConcidirRota: function() {
            this._carregarHabilidades();
		},

        _carregarHabilidades: async function() {
			try {
				const habilidades = await HabilidadeService.obterTodasHabilidades(this._filtros);
				const modeloHabilidade = new JSONModel(habilidades);
				this.getView().setModel(modeloHabilidade);
				this.obterRotiador().navTo(ROTA_HABILIDADES, Object.keys(this._filtros).length === 0 ? {} : { "?query": this._filtros });
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
			var primeiraDataSelecionada = 0;
			var calendario = evento.getSource();
			var datasSelecionadas = calendario.getSelectedDates()[primeiraDataSelecionada];
		
			if (datasSelecionadas) {
				var formatadorDeData = sap.ui.core.format.DateFormat.getDateTimeInstance({
					pattern: "yyyy-MM-dd'T'HH:mm:ss'Z'"
				});
				this._filtros.database = formatadorDeData.format(datasSelecionadas.getStartDate());
				this._filtros.datateto = formatadorDeData.format(datasSelecionadas.getEndDate());
			}
		},

		aoAplicarFiltrosHabilidade: async function(evento) {
			this._carregarHabilidades();
		},

		
		aoResetarFiltrosHabilidade: function() {
			this._filtros = {};
			this.byId(ID_CALENDARIO).removeAllSelectedDates();

			this._carregarHabilidades();
		},
    });
});