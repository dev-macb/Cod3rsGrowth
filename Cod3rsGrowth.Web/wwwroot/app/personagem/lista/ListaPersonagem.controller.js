sap.ui.define([
	"coders-growth/app/common/BaseController",
	"coders-growth/app/common/HttpService",
	"coders-growth/app/common/Constantes",
	"coders-growth/app/models/Formatador",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat",
], function(BaseController, HttpService, Constantes, Formatador, JSONModel, DateFormat) {
	"use strict";

	const FRAGMENTO_FILTRO_PERSONAGEM = "coders-growth.app.personagem.lista.FiltroPersonagem";

	return BaseController.extend("coders-growth.app.personagem.lista.ListaPersonagem", {
		formatter: Formatador,

		onInit: function() {
			this._filtros = {};
			this.__vincularRota(Constantes.ROTA_PERSONAGENS, this._aoConcidirRota);
        },

		_aoConcidirRota: function() {
            this._carregarPersonagens();
		},

		_carregarPersonagens: async function() {
			this.__exibirEspera(async () => {
				const personagens = await HttpService.get(Constantes.URL_PERSONAGEM, null, this._filtros);
				this.__definirModelo(new JSONModel(personagens), Constantes.MODELO_LISTA_PERSONAGENS);
				this.__navegarPara(Constantes.ROTA_PERSONAGENS, Object.keys(this._filtros).length === 0 ? {} : { "?query": this._filtros });
			});
		},

		irAdicionarPersonagem: function() {
			this.__navegarPara(Constantes.ROTA_ADICIONAR_PERSONAGEM);
		},

		aoFiltrarPersonagemPorNome(evento) {
			const filtroNome = evento.getSource().getValue();
			
			if (filtroNome) { this._filtros.nome = filtroNome; } 
			else { delete this._filtros.nome; }	

			this._carregarPersonagens();
		},

		aoAbrirFiltros: async function() {
			this.__exibirEspera(async () => {
				this.dialogoFiltros ??= await this.loadFragment({ 
					name: FRAGMENTO_FILTRO_PERSONAGEM, 
					controller: this
				});
				this.dialogoFiltros.open();
			});
		},

		tratarSelecaoDeDatas: function(evento) {
			var primeiraDataSelecionada = 0;
			var calendario = evento.getSource();
			var datasSelecionadas = calendario.getSelectedDates()[primeiraDataSelecionada];
			
			if (datasSelecionadas) {
				var formatadorDeData = DateFormat.getDateTimeInstance({
					pattern: "yyyy-MM-dd'T'HH:mm:ss'Z'"
				});
				this._filtros.database = formatadorDeData.format(datasSelecionadas.getStartDate());
				this._filtros.datateto = formatadorDeData.format(datasSelecionadas.getEndDate());
			}
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
			this.__obterElementoPorId(Constantes.ID_CALENDARIO).removeAllSelectedDates();

			this._carregarPersonagens();
		},

		aoClicarEmVerDetalhes: function(elemento) {
			this.__navegarPara(Constantes.ROTA_PERSONAGEM, { idPersonagem: elemento.getSource().getBindingContext("personagens").getProperty("id") });
		}
	});
});