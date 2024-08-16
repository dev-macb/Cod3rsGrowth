sap.ui.define([
    "sap/ui/test/Opa5"
], function(Opa5) {
    "use strict";

    return Opa5.extend("coders-growth.tests.arrangements.Startup", {
        iniciarAplicacao: function(parametroOpcoes) {            
            var opcoes = parametroOpcoes || {};
            opcoes.delay = opcoes.delay || 50;
            
            this.iStartMyUIComponent({
                componentConfig: {
                    name: "coders-growth",
                    async: true,
                    manifest: true
                },
                hash: opcoes.hash,
                autoWait: opcoes.autoWait
            });
        }
    });
});