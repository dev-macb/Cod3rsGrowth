sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function(Opa5, Press, PropertyStrictEquals) {
    "use strict";

    const nomeDaView = "notFound.NotFound";

    Opa5.createPageObjects({
        naPaginaNotFound: {
            actions: {
                aoClicarEmVerVoltar: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão Voltar não encontrado."
                    });
                }
            },
            assertions: {
                verificaUrl: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "notFound", "A URL corresponde a página Not Found.");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                verificaPropriedadesDaPagina: function() {
                    return this.waitFor({
                        controlType: "sap.m.MessagePage",
                        viewName: nomeDaView,
                        matchers: [
                            new PropertyStrictEquals({ name: "title", value: "Não Encontrado" }),
                            new PropertyStrictEquals({ name: "text", value: "Desculpe, mas o recurso solicitado não está disponível." }),
                            new PropertyStrictEquals({ name: "description", value: "Verifique a URL e tente novamente." })
                        ],
                        success: function(oPage) {
                            Opa5.assert.ok(oPage, "As propriedades { title, text, description } da página NotFound estão corretos.");
                        },
                        errorMessage: "Uma ou mais propriedades { title, text, description } da página NotFound estão incorretos."
                    });
                }
            }
        }
    });
});