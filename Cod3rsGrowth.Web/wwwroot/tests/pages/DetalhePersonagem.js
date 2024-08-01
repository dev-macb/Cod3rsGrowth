sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function (Opa5, PropertyStrictEquals) {
    "use strict";

    Opa5.createPageObjects({
        naPaginaDetalhePersonagem: {
            actions: {},
            assertions: {
                verificaDetalhesDoPersonagem: function () {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        id: "detalhePersonagem",
                        success: function (oPage) {
                            Opa5.assert.ok(oPage, "A página de detalhes do personagem foi encontrada.");
                        },
                        errorMessage: "A página de detalhes do personagem não foi encontrada."
                    });
                },
                verificaUrlDetalhePersonagem: function () {
                    return this.waitFor({
                        success: function () {
                            var oHashChanger = sap.ui.core.routing.HashChanger.getInstance();
                            var sHash = oHashChanger.getHash();
                            Opa5.assert.strictEqual(sHash, "detalhePersonagem/{idPersonagem}", "A URL de detalhes do personagem está correta.");
                        },
                        errorMessage: "A URL de detalhes do personagem está incorreta."
                    });
                },
                verificaTituloListaPersonagem: function () {
                    return this.waitFor({
                        controlType: "sap.m.Title",
                        matchers: new PropertyStrictEquals({
                            name: "text",
                            value: "Lista de Personagens"
                        }),
                        success: function (oTitle) {
                            Opa5.assert.ok(oTitle, "O título da lista de personagens foi verificado.");
                        },
                        errorMessage: "O título da lista de personagens não foi encontrado."
                    });
                }
            }
        }
    });
});