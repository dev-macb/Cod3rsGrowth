sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
], function(Opa5, Press, PropertyStrictEquals) {
    "use strict";

    const nomeDaView = "home.Home";

    Opa5.createPageObjects({
        naPaginaHome: {
            actions: {
                aoClicarEmVerListaPersonagem: function() {
                    return this.waitFor({
                        id: "btnVerListaPersonagem",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Ver Lista de Personagens' não encontrado"
                    });
                },
                aoClicarEmVerListaHabilidade: function() {
                    return this.waitFor({
                        id: "btnVerListaHabilidade",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Ver Lista de Habilidades' não encontrado"
                    });
                }
            },
            assertions: {
                verificaUrl: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "", "A URL corresponde a página Home");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                verificaTituloDaPagina: function(texto) {
                    return this.waitFor({
                        id: "tituloPaginaHome",
                        viewName: nomeDaView,
                        matchers: new PropertyStrictEquals({ name: "text", value: texto }),
                        success: function(pagina) {
                            Opa5.assert.ok(pagina, `Página Home tem o titulo: ${texto}`);
                        },
                        errorMessage: `Página Home tem o titulo: ${texto}`
                    });
                },
                verificaTituloDoPainel: function(texto) {
                    return this.waitFor({
                        id: "tituloPainelHome",
                        viewName: nomeDaView,
                        matchers: new PropertyStrictEquals({ name: "text", value: texto }),
                        success: function(painel) {
                            Opa5.assert.ok(painel, `Painel principal da página Home tem o titulo: ${texto}`);
                        },
                        errorMessage: `Painel principal da página Home tem o titulo: ${texto}`
                    });
                }
            }
        }
    });
});
