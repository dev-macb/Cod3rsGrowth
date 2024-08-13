sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/UIComponent",
	"coders-growth/common/Constantes",
], function(Controller, UIComponent, Constantes) {
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
        }
	});
});