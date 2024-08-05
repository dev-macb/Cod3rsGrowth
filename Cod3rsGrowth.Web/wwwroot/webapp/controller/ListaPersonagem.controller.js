sap.ui.define([
	"coders-growth/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat",
	"../services/PersonagemService"
], function(BaseController, JSONModel, DateFormat, PersonagemService) {
	"use strict";

	const ROTA_PERSONAGENS = "personagens";
	const ID_CALENDARIO = "calendario";

	return BaseController.extend("coders-growth.controller.ListaPersonagem", {
		onInit: function() {
			this.vincularRota(ROTA_PERSONAGENS, this._aoConcidirRota);
        },

		_aoConcidirRota: function() {
			this._filtros = {};
            this._carregarPersonagens();
		},

		_carregarPersonagens: async function() {
			const personagens = await PersonagemService.obterTodosPersonagens(this._filtros);
			const modeloPersonagem = new JSONModel(personagens);

			this.getView().setModel(modeloPersonagem);
			this.obterRotiador().navTo(ROTA_PERSONAGENS, Object.keys(this._filtros).length === 0 ? {} : { "?query": this._filtros });
		},

		irAdicionarPersonagem: function() {
			console.log("IR ADICIONAR PERSONAGEM")
			this.obterRotiador().navTo("adicionarPersonagem", {});
		},

		aoFiltrarPersonagemPorNome(evento) {
			const filtroNome = evento.getSource().getValue();
			
			if (filtroNome) { this._filtros.nome = filtroNome; } 
			else { delete this._filtros.nome; }	

			this._carregarPersonagens();
		},

		aoAbrirFiltros: async function() {
			this.dialogoFiltros ??= await this.loadFragment({
				name: "coders-growth.view.FiltroPersonagem",
				controller: this
			});
			this.dialogoFiltros.open();
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
			this.byId(ID_CALENDARIO).removeAllSelectedDates();

			this._carregarPersonagens();
		},

		aoClicarEmVerDetalhes: function(elemento) {
			this.obterRotiador().navTo("personagem", { idPersonagem: elemento.getSource().getBindingContext().getProperty("id") })
		},

		formatter: {
            iconePersonagem: function(eVilao) {
                return eVilao ? "images/luva_vermelha.png" : "images/luva_azul.png";
            }
        }
	});
});