sap.ui.define([
	"coders-growth/common/BaseController",
	"coders-growth/common/Constantes"
], function (BaseController, Constantes) {
	"use strict";

	return BaseController.extend("coders-growth.controller.Home", {
		aoClicarEmVerListaPersonagem() {
			this.__navegarPara(Constantes.ROTA_PERSONAGENS);
		},

		aoClicarEmVerListaHabilidade() {
			this.__navegarPara(Constantes.ROTA_HABILIDADES);
		}
	});
});