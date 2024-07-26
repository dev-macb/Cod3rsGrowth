sap.ui.define([
	"coders-growth/controller/BaseController",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat"
], function(BaseController, JSONModel, DateFormat) {
	"use strict";

	return BaseController.extend("coders-growth.controller.ListaPersonagem", {
		onInit: function() {
			this._filtros = {};
            this._carregarPersonagens();
        },


		_carregarPersonagens: async function() {
			const urlObterTodasHabilidades = new URL("https://localhost:5051/api/Personagem");
		
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
				this.obterRotiador().navTo("personagens", Object.keys(this._filtros).length === 0 ? {} : { "?query": this._filtros });
			} catch (erro) {
				console.error(erro);
			}
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
			var calendario = evento.getSource();
			var datasSelecionadas = calendario.getSelectedDates()[0];
			
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
			this.byId("calendarario").removeAllSelectedDates();

			this._carregarPersonagens();
		},


		formatter: {
            iconePersonagem: function(eVilao) {
                return eVilao ? "images/luva_vermelha.png" : "images/luva_azul.png";
            }
        }
	});
});