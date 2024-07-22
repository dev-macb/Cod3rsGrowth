sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/actions/Press"
], function(Opa5, PropertyStrictEquals, Press) {
    "use strict";

    const nomeDaView = "coders-growth.view.ListaHabilidade";

    Opa5.createPageObjects({
        naListaHabilidade: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        id: "__xmlview3--paginaListaHabilidade-navButton",
                        actions: new Press(),
                        errorMessage: "Botão de voltar não encontrado."
                    });
                }
            },
            assertions: {
                deveVerificarUrlHabilidades: function() {
                    return this.waitFor({
                        success: function() {
                            const sHash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(sHash, "habilidades", "A URL está correta");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                deveVerificarTituloListaHabilidade: function() {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: nomeDaView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Lista de Habilidades" }),
                        success: function(oPage) {
                            Opa5.assert.ok(oPage, "Navegou para a lista de habilidades e a página tem o título correto");
                        },
                        errorMessage: "Não foi possível navegar para a lista de habilidades ou o título está incorreto"
                    });
                }
            }
        }
    });
});