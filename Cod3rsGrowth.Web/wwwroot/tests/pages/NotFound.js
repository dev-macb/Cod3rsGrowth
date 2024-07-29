sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press"
], function(Opa5, Press) {
    "use strict";

    const nomeDaView = "NotFound";

    Opa5.createPageObjects({
        naPaginaNotFound: {
            actions: {
                aoClicarEmVerVoltarHome: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Voltar para Home' não encontrado."
                    });
                }
            },
            assertions: {
                verificaUrlPaginaNotFound: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "notFound", "Navegou para o endpoind da pagina NotFound");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                verificaTituloPaginaNotFound: function() {
                    return this.waitFor({
                        controlType: "sap.m.MessagePage",
                        viewName: nomeDaView,
                        matchers: new sap.ui.test.matchers.PropertyStrictEquals({ name: "title", value: "Não Encontrado" }),
                        success: function(oPage) {
                            Opa5.assert.ok(oPage, "O título da página NotFound está correto: 'Não Encontrado'");
                        },
                        errorMessage: "O título da página NotFound não está correto"
                    });
                }
            }
        }
    });
});