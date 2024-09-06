sap.ui.define([
	"coders-growth/app/common/BaseController",
	"coders-growth/app/common/Constantes"
], function (BaseController, Constantes) {
	"use strict";

	return BaseController.extend("coders-growth.app.home.Home", {
		aoClicarEmVerListaPersonagem() {
			this.__navegarPara(Constantes.ROTA_PERSONAGENS);
		},

		aoClicarEmVerListaHabilidade() {
			this.__navegarPara(Constantes.ROTA_HABILIDADES);
		}
	});
});