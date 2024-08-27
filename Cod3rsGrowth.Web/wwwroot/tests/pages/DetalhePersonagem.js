sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Ancestor",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function (Opa5, Press, Ancestor, Properties, PropertyStrictEquals) {
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
                aoClicarNoBotaoExcluirPersonagem: function() {
                    return this.waitFor({
                        id: "botaoExcluirPersonagem",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão Excluir."
                    });
                },
                aoClicarNoBotaoDoMessageBox: function (textoButao) {
                    return this.waitFor({
						controlType: "sap.m.Button",
						matchers: [
							new Properties({ text: textoButao }),
							new Ancestor(Opa5.getContext().dialog, false) 
						],
						actions: new Press(),
						success: function () {
							Opa5.assert.ok(true, "Sucesso ao fechar MessageBox ao clicar no botao Ok.");
						},
						errorMessage: "Falha ao fechar MessageBox ao clicar no botao Ok."
                    });
                },
            },
            assertions: {
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
                },
                verificaMensagemDeConfirmacao: function (titulo, mensagem) {
                    return this.waitFor({
                        controlType: "sap.m.Dialog",
                        matchers: new Properties({ title: titulo }),
                        success: function (listaDeDialogos) {
                            var dialogo = listaDeDialogos[0];
                            this.waitFor({
                                controlType: "sap.m.Text",
                                matchers: new Ancestor(dialogo, false),
                                success: function (listaDeTextos) {
                                    const texto = listaDeTextos[0].getText();
                                    Opa5.assert.strictEqual(texto, mensagem, `O MessageBox apareceu com a mensagem '${mensagem}'`);
                                },
                                errorMessage: `O MessageBox apareceu com o título '${titulo}', mas a mensagem não correspondeu a: "${mensagem}".`
                            });
                        },
                        errorMessage: `O MessageBox não apareceu com o título '${titulo}'.`
                    });
                }                
            }
        }
    });
});