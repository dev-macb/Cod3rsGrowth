sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent"
], function(Controller, History, UIComponent) {
	"use strict";

	return Controller.extend("coders-growth.controller.BaseController", {
		obterRotiador : function () {
			return UIComponent.getRouterFor(this);
		},


		navegarPara: function (rotaDestino) {
			if (rotaDestino) { this.obterRotiador().navTo(rota); }
			else { this.obterRotiador().navTo("home"); }
		},


		navegarDeVolta: function () {
			var historico = History.getInstance();
            var hashAnterior = historico.getPreviousHash();            

            if (hashAnterior === undefined || hashAnterior === "notFound") {
                this.obterRotiador().navTo("home");
            } 
            else {
                window.history.go(-1);
            }
		}
	});
});