sap.ui.define([
	"sap/ui/test/Opa5",
], function(Opa5) {
	"use strict";

	return Opa5.extend("sap.ui.demo.bulletinboard.test.integration.arrangements.Startup", {
		iStartMyApp: function (parametroOpcoes) {
			var opcoes  = parametroOpcoes || {};
			opcoes.delay = opcoes.delay || 1;
			this.iStartMyUIComponent({
				componentConfig: { name: "coders-growth", async: true, manifest: true },
				hash: opcoes.hash,
				autoWait: opcoes.autoWait
			});
		}
	});
});