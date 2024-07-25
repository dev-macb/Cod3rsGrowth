sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
], function(Opa5, Press) {
    "use strict";

    const nomeDaView = "Home";

    Opa5.createPageObjects({
        naPaginaHome: {
            actions: {
                aoClicarEmVerListaPersonagem: function() {
                    return this.waitFor({
                        id: "btnVerListaPersonagem",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Ver Lista de Personagens' não encontrado."
                    });
                },
                aoClicarEmVerListaHabilidade: function() {
                    return this.waitFor({
                        id: "btnVerListaHabilidade",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Ver Lista de Habilidades' não encontrado."
                    });
                },
                aoNavegarParaRotaInexistente: function() {
                    return this.waitFor({
                        success: function() {
                            sap.ui.test.Opa5.getHashChanger().setHash("RotaInexistente");
                        }
                    });
                }
            },
            assertions: {
                verificaUrlPaginaHome: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "", "Navegou para o endpoind da pagina Home");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                verificarUrlPaginaHome: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "", "Navegou para o endpoint Home");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                verificaTituloPaginaHome: function() {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: "Home",
                        matchers: new sap.ui.test.matchers.Properties({
                            title: "Coder's Growth"
                        }),
                        success: function(oPage) {
                            Opa5.assert.ok(oPage, "O título da página Home está correto");
                        },
                        errorMessage: "Título da página Home não está correto"
                    });
                }
            }
        }
    });
});
