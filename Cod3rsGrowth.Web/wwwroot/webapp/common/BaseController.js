sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"coders-growth/common/Constantes",
	"sap/ui/core/UIComponent",
	"sap/m/MessageBox",
], function(Controller, Constantes, UIComponent, MessageBox) {
	"use strict";

	return Controller.extend("coders-growth.controller.BaseController", {
		__obterRotiador : function () {
			return UIComponent.getRouterFor(this);
		},

		__navegarPara: function (rotaDestino, parametros = {}) {
			if (rotaDestino) { this.__obterRotiador().navTo(rotaDestino, parametros); }
			else { this.__obterRotiador().navTo(Constantes.ROTA_HOME); }
		},

		__vincularRota: function(rota, metodo) {
            this.__obterRotiador().getRoute(rota).attachMatched(metodo, this);
        },

		__definirModelo: function(modelo, nome) {
            this.getView().setModel(modelo, nome);
        },

        __obterModelo: function(nome) {
            return this.getView().getModel(nome);
        },

        __obterVisualizacao: function() {
            return this.getView();
        },

        __obterElementoPorId: function(id) {
            return this.byId(id);
        },

		__exibirErroModal: function (erro) {
			let mensagemErro = "Ocorreu um erro desconhecido";
            let detalhesErro = "Sem stacktrace disponível";
        
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
                    title: erro.Title || erro.title,
                    details: detalhesErro,
                    contentWidth: "500px"
                }
            );
		}
	});
});