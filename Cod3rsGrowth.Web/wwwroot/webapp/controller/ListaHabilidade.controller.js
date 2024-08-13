sap.ui.define([
	"coders-growth/common/BaseController",
	"coders-growth/common/HttpService",
	"coders-growth/common/Constantes",
	"sap/m/MessageBox",
	"sap/ui/model/json/JSONModel"
], function(BaseController, HttpService, Constantes, MessageBox, JSONModel) {
	"use strict";

	const ID_CALENDARIO = "calendario";

	return BaseController.extend("coders-growth.controller.ListaHabilidade", {
        onInit: function() {
			this._filtros = {};
			this.__vincularRota(Constantes.ROTA_HABILIDADES, this._aoConcidirRota);
        },

		_aoConcidirRota: function() {
            this._carregarHabilidades();
		},

        _carregarHabilidades: async function() {
			try {
				const habilidades = await HttpService.get(Constantes.URL_HABILIDADE, null, this._filtros);
				this.__definirModelo(new JSONModel(habilidades));
				this.__navegarPara(Constantes.ROTA_HABILIDADES, Object.keys(this._filtros).length === 0 ? {} : { "?query": this._filtros });
			} 
			catch (erro) {
				this._exibirErroModal(erro);
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

		_exibirErroModal: function(erro) {  
            let mensagemErro = "Ocorreu um erro desconhecido!";
            let detalhesErro = "Sem stacktrace disponível.";
        
            if (erro.Extensions && erro.Extensions.FluentValidation) {
                mensagemErro = Object.values(erro.Extensions.FluentValidation).join(" ");
            } 
            else if (erro.detail) {
                mensagemErro = erro.detail;
            }
        
            if (erro.Title || erro.title) {
                detalhesErro = `Status: ${erro.Status || erro.status} - ${erro.Detail || erro.errors?.$ || "Sem detalhes adicionais"}`;
            }
        
            MessageBox.error(
                mensagemErro,
                {
                    title: erro.Title || erro.title || "Erro ao adicionar personagem",
                    details: detalhesErro,
                    contentWidth: "500px"
                }
            );
        }
    });
});