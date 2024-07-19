sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/actions/Press"
], function(Opa5, PropertyStrictEquals, Press) {
    "use strict";

    const nomeDaView = "coders-growth.view.ListaPersonagem";

    Opa5.createPageObjects({
        naListaPersonagem: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        id: "__xmlview1--paginaListaPersonagem-navButton",
                        actions: new Press(),
                        errorMessage: "Botão de voltar não encontrado."
                    });
                }
            },
            assertions: {
                deveVerificarUrlPersonagens: function() {
                    return this.waitFor({
                        success: function() {
                            const sHash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(sHash, "personagens", "A URL está correta");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                deveVerificarTituloListaPersonagem: function() {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: nomeDaView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Lista de Personagens" }),
                        success: function(pagina) {
                            Opa5.assert.ok(pagina, "Navegou para a lista de personagens e a página tem o título correto");
                        },
                        errorMessage: "Não foi possível navegar para a lista de personagens ou o título está incorreto"
                    });
                }
            }
        }
    });
});
