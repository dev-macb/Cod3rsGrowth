sap.ui.define([
	"coders-growth/controller/BaseController"
], function (BaseController) {
	"use strict";

	return BaseController.extend("coders-growth.controller.DetalhePersonagem", {
		onInit: function () {
            this.obterRotiador().getRoute("personagens").attachMatched(this._aoCarregarDetalhes, this);
		},

        _aoCarregarDetalhes: function () {
            const parametros = this.obterRotiador().getParameter("arguments").getHashChanger().getHash().split("/");
            console.log(parametros)
		},

		_onBindingChange: function (oEvent) {
			if (!this.getView().getBindingContext()) {
				this.getRouter().getTargets().display("notFound");
			}
		}
	});
});