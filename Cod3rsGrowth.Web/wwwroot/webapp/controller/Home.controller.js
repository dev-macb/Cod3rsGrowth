sap.ui.define([
	"coders-growth/controller/BaseController"
], function (BaseController) {
	"use strict";

	const rotaPersonagens = "personagens";
	const rotaHabilidades = "habilidades";

	return BaseController.extend("coders-growth.controller.Home", {
		irListaPersonagem() {
			this.__obterRotiador().navTo(rotaPersonagens);
		},

		irListaHabilidade() {
			this.__obterRotiador().navTo(rotaHabilidades);
		}
	});
});