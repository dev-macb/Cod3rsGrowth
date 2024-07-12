sap.ui.define([
	"coders-growth/controller/BaseController"
], function (BaseController) {
	"use strict";

	return BaseController.extend("coders-growth.controller.Home", {
		irListaPersonagem() {
			this.obterRotiador().navTo("personagens");
		},

		irListaHabilidade() {
			this.obterRotiador().navTo("habilidades");
		}
	});
});