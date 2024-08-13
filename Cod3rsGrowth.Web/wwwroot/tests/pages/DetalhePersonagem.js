sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/core/routing/HashChanger",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function (Opa5, Press, HashChanger, PropertyStrictEquals) {
    "use strict";

    const nomeDaView = "DetalhePersonagem";

    Opa5.createPageObjects({
        naPaginaDetalhePersonagem: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        matchers: function(botao) {
                            return botao.getId().includes("detalhePersonagem-navButton");
                        },
                        actions: new Press(),
                        errorMessage: "Botão de voltar não encontrado."
                    });
                },
            },
            assertions: {
                verificaUrl: function (idEsperado) {
                    return this.waitFor({
                        success: function () {
                            var hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, `personagens/${idEsperado}`, "A URL de detalhes do personagem está correta.");
                        },
                        errorMessage: "A URL de detalhes do personagem está incorreta."
                    });
                },
                verificaDetalhesDoPersonagem: function () {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        check: function (textos) {
                            var idsRequeridos = ["txtVida", "txtEnergia", "txtVelocidade", "txtForca", "txtInteligencia", "txtEVilao"];
                            var todosCamposEncontrados = idsRequeridos.every(function (id) {
                                var texto = textos.find(function (texto) {
                                    return texto.getId().indexOf(id) !== -1;
                                });
                                return texto && texto.getText() !== "";
                            });
                            return todosCamposEncontrados;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "Todos os campos de detalhes do personagem foram encontrados e não estão vazios.");
                        },
                        errorMessage: "Alguns campos de detalhes do personagem não foram encontrados ou estão vazios."
                    });
                },
                verificaTituloListaPersonagem: function () {
                    return this.waitFor({
                        controlType: "sap.m.Title",
                        matchers: new PropertyStrictEquals({ name: "text", value: "Detalhes do Personagem" }),
                        success: function (titulo) {
                            Opa5.assert.ok(titulo, "O título da lista de personagens foi verificado.");
                        },
                        errorMessage: "O título da lista de personagens não foi encontrado."
                    });
                },
                verificaQuatidadeDaListaDeHabilidades: function (quantidadeEsperada) {
                    return this.waitFor({
                        id: "listaHabilidade",
                        viewName: nomeDaView,
                        success: function (lista) {
                            var quantidadeDeItens = lista.getItems().length;
                            Opa5.assert.strictEqual(quantidadeDeItens, quantidadeEsperada, "A lista de habilidades possui " + quantidadeEsperada + " itens.");
                        },
                        errorMessage: "A lista de habilidades não possui a quantidade esperada de itens."
                    });
                },
                verificaClasseTextoEVilao: function (classeEsperada) {
                    return this.waitFor({
                        id: "txtEVilao",
                        viewName: "DetalhePersonagem",
                        success: function (texto) {
                            var classeCSS = texto.aCustomStyleClasses[0];
                            var possuiClasseCSS = classeCSS.includes(classeEsperada);
                            Opa5.assert.ok(possuiClasseCSS, "O texto de propósito tem a classe " + classeEsperada);
                        },
                        errorMessage: "O texto de propósito não tem a classe esperada."
                    });
                }
            }
        }
    });
});