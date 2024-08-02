sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/UIComponent"
], function(Controller, UIComponent) {
	"use strict";

	const ROTA_HOME = "home";

	return Controller.extend("coders-growth.controller.BaseController", {
		obterRotiador : function () {
			return UIComponent.getRouterFor(this);
		},

		navegarPara: function (rotaDestino) {
			if (rotaDestino) { this.obterRotiador().navTo(rotaDestino); }
			else { this.obterRotiador().navTo(ROTA_HOME); }
		},

		vincularRota: function(rota, metodo) {
            this.obterRotiador().getRoute(rota).attachMatched(metodo, this);
        }
	});
});