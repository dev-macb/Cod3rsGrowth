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

		navegarDeVolta: function () {
			var historico = History.getInstance();
            var hashAnterior = historico.getPreviousHash();            

            if (hashAnterior === undefined || hashAnterior === "notFound") {
                var rotiador = UIComponent.getRouterFor(this);
                rotiador.navTo("home", {}, true);
            } 
            else {
                window.history.go(-1);
            }
		}
	});
});