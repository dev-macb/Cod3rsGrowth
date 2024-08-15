sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function (Opa5, Press, PropertyStrictEquals) {
    "use strict";

    const nomeDaView = "DetalhePersonagem";

    Opa5.createPageObjects({
        naPaginaDetalhePersonagem: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        id: "botaoVoltar",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar."
                    });
                },
            },
            assertions: {
                deveMostrarMessageToast: function () {
                    return this.waitFor({
                        controlType: "sap.m.MessageToast",
                        success: function () {
                            Opa5.assert.ok(true, "Um MessageToast foi exibido.");
                        },
                        errorMessage: "Nenhum MessageToast foi exibido."
                    });
                },
                verificaUrl: function (idEsperado) {
                    return this.waitFor({
                        success: function () {
                            var hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, `personagens/${idEsperado}`, "A URL corresponde a página DetalhePersonagem");
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
                            Opa5.assert.ok(true, "Todos os campos do formulário do personagem possuem dados");
                        },
                        errorMessage: "Alguns campos do formulário do personagem não foram encontrados ou estão vazios"
                    });
                },
                verificaTituloDaPagina: function (texto) {
                    return this.waitFor({
                        controlType: "sap.m.Title",
                        matchers: new PropertyStrictEquals({ name: "text", value: texto }),
                        success: function (titulo) {
                            Opa5.assert.ok(titulo, `A página possui titulo '${texto}'`);
                        },
                        errorMessage: `A página possui titulo '${texto}'`
                    });
                },
                verificaQuatidadeDaListaDeHabilidades: function (quantidadeEsperada) {
                    return this.waitFor({
                        id: "listaHabilidade",
                        viewName: nomeDaView,
                        success: function (lista) {
                            var quantidadeDeItens = lista.getItems().length;
                            Opa5.assert.strictEqual(quantidadeDeItens, quantidadeEsperada, `A lista de habilidades possui '${quantidadeEsperada}' itens`);
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
                            Opa5.assert.ok(possuiClasseCSS, `O texto do Propósito do personagem possui a classe '${classeEsperada}'`);
                        },
                        errorMessage: "O texto de propósito não tem a classe esperada."
                    });
                }
            }
        }
    });
});