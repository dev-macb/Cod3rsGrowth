sap.ui.define([
	"coders-growth/common/BaseController",
	"coders-growth/common/HttpService",
	"coders-growth/common/Constantes",
	"sap/ui/model/json/JSONModel"
], function(BaseController, HttpService, Constantes, JSONModel) {
	"use strict";

	const FRAGMENTO_FILTRO_HABILIDADE = "coders-growth.view.FiltroHabilidade";
	return BaseController.extend("coders-growth.controller.ListaHabilidade", {
        onInit: function() {
			this._filtros = {};
			this.__vincularRota(Constantes.ROTA_HABILIDADES, this._aoConcidirRota);
        },

		_aoConcidirRota: function() {
            this._carregarHabilidades();
		},

        _carregarHabilidades: async function() {
			this.__exibirEspera(async () => {
				const habilidades = await HttpService.get(Constantes.URL_HABILIDADE, null, this._filtros);
				this.__definirModelo(new JSONModel(habilidades));
				this.__navegarPara(Constantes.ROTA_HABILIDADES, Object.keys(this._filtros).length === 0 ? {} : { "?query": this._filtros });
			});
		},

        aoFiltrarHabilidadePorNome: function(evento) {
			const filtroNome = evento.getSource().getValue();
			
			if (filtroNome) { this._filtros.nome = filtroNome; } 
			else { delete this._filtros.nome; }	

			this._carregarHabilidades();
		},

		aoAbrirFiltrosHabilidade: async function() {
			this.__exibirEspera(async () => {
				this.dialogoFiltrosHabilidade ??= await this.loadFragment({
					name: FRAGMENTO_FILTRO_HABILIDADE,
					controller: this
				});
				this.dialogoFiltrosHabilidade.open();
			});
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

		aoAplicarFiltrosHabilidade: async function() {
			this._carregarHabilidades();
		},

		
		aoResetarFiltrosHabilidade: function() {
			this._filtros = {};
			this.__obterElementoPorId(Constantes.ID_CALENDARIO).removeAllSelectedDates();

			this._carregarHabilidades();
		}
    });
});