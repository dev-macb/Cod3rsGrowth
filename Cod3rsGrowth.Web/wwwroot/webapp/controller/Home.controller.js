sap.ui.define([
	"coders-growth/common/BaseController",
	"coders-growth/common/Constantes"
], function (BaseController, Constantes) {
	"use strict";

	return BaseController.extend("coders-growth.controller.Home", {
		irListaPersonagem() {
			this.__navegarPara(Constantes.ROTA_PERSONAGENS);
		},

		irListaHabilidade() {
			this.__navegarPara(Constantes.ROTA_HABILIDADES);
		}
	});
});