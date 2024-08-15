sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/core/util/MockServer"
], function(Opa5, MockServer) {
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

            this.iniciarServidorMock();
        },
        iniciarServidorMock: function() {
            var servidorMock = new MockServer({ rootUri: "/api/" });
            var caminhoMock = sap.ui.require.toUrl("coders-growth/localService");
            console.log(caminhoMock + "/metadata.xml")
            servidorMock.simulate(caminhoMock + "/metadata.xml", {
                sMockdataBaseUrl: caminhoMock + "/mockdata/",
                bGenerateMissingMockData: true
            });
            
            servidorMock.start();
        }
    });
});