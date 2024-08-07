sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/UIComponent"
], function(Controller, UIComponent) {
	"use strict";

	const ROTA_HOME = "home";

	return Controller.extend("coders-growth.controller.BaseController", {
		__obterRotiador : function () {
			return UIComponent.getRouterFor(this);
		},

		__navegarPara: function (rotaDestino) {
			console.log(rotaDestino)
			if (rotaDestino) { this.__obterRotiador().navTo(rotaDestino); }
			else { this.__obterRotiador().navTo(ROTA_HOME); }
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