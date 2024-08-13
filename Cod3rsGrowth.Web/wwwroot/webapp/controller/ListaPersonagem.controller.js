sap.ui.define([
	"coders-growth/common/BaseController",
	"coders-growth/common/HttpService",
	"coders-growth/common/Constantes",
	"sap/m/MessageBox",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/format/DateFormat",
], function(BaseController, HttpService, Constantes, MessageBox, JSONModel, DateFormat) {
	"use strict";

	const ID_CALENDARIO = "calendario";
	const IMG_LUVA_AZUL = "images/luva_azul.png";
	const IMG_LUVA_VERMELHA = "images/luva_vermelha.png";

	return BaseController.extend("coders-growth.controller.ListaPersonagem", {
		onInit: function() {
			this._filtros = {};
			this.__vincularRota(Constantes.ROTA_PERSONAGENS, this._aoConcidirRota);
        },

		_aoConcidirRota: function() {
            this._carregarPersonagens();
		},

		_carregarPersonagens: async function() {
			try {
				const personagens = await HttpService.get(Constantes.URL_PERSONAGEM, null, this._filtros);
				this.__definirModelo(new JSONModel(personagens));
				this.__navegarPara(Constantes.ROTA_PERSONAGENS, Object.keys(this._filtros).length === 0 ? {} : { "?query": this._filtros });
			}
			catch (erro) {
				this._exibirErroModal(erro);
			}
		},

		irAdicionarPersonagem: function() {
			this.__navegarPara("formularioPersonagem");
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
			this.__navegarPara(Constantes.ROTA_PERSONAGEM, { idPersonagem: elemento.getSource().getBindingContext().getProperty("id") });
		},

		formatter: {
            iconePersonagem: function(eVilao) {
                return eVilao ? IMG_LUVA_VERMELHA : IMG_LUVA_AZUL;
            }
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
                detalhesErro = `Status: ${erro.Status || erro.status}  -  ${erro.Detail || erro.errors?.$ || "Sem detalhes adicionais"}`;
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