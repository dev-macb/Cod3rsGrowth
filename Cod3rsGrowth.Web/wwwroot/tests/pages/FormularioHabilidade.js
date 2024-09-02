sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/Ancestor",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function (Opa5, Press, EnterText, Ancestor, Properties, PropertyStrictEquals) {
    "use strict";

    const nomeDaView = "FormularioHabilidade";

    Opa5.createPageObjects({
        noFormularioHabilidade: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        id: "botaoVoltar",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar."
                    });
                },
                aoClicarNoBotaoSalvar: function () {
                    return this.waitFor({
                        id: "butaoSalvarHabilidade",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão de salvar não encontrado ou não clicável."
                    });
                },
                aoFecharMessageBox: function (textoButao) {
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
                aoInserirNome: function (texto) {
                    return this.waitFor({
                        id: "inputNome",
                        viewName: nomeDaView,
                        actions: new EnterText({ text: texto }),
                        errorMessage: "Campo 'Nome' não encontrado ou não editável."
                    });
                },
                aoInserirDescricao: function (texto) {
                    return this.waitFor({
                        id: "inputDescricao",
                        viewName: nomeDaView,
                        actions: new EnterText({ text: texto }),
                        errorMessage: "Campo 'Descrição' não encontrado ou não editável."
                    });
                },
                aoClicarNoBotaoSalvar: function () {
                    return this.waitFor({
                        id: "butaoSalvarHabilidade",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão de salvar não encontrado ou não clicável."
                    });
                },
            },
            assertions: {    
                verificaTipoDosInputs: function (tipo) {
                    const idsDosInputs = ["inputNome", "inputDescricao"];
                    
                    idsDosInputs.forEach(id => {
                        this.waitFor({
                            id: id,
                            viewName: nomeDaView,
                            success: function (input) {
                                const estadoValor = input.getValueState();
                                Opa5.assert.strictEqual(
                                    estadoValor,
                                    tipo,
                                    `O input '${id}' está corretamente com o ValueState '${tipo}'.`
                                );
                            },
                            errorMessage: `O input com id '${id}' não foi encontrado ou não possui um ValueState '${tipo}'.`
                        });
                    });
                },
                deveMostrarMessageBox: function (titulo, mensagem) {
					return this.waitFor({
						controlType: "sap.m.Dialog",
						matchers: new Properties({ title: titulo }),
						success: function (dialogo) {
							this.waitFor({
                                controlType: "sap.m.Text",
                                matchers: new Ancestor(dialogo[0], false),
                                success: function(texto) {
                                    const txt = texto[0].getText();
                                    Opa5.assert.strictEqual(txt, mensagem, `O MessageBox apareceu com a mensagem '${mensagem}'`);
                                },
                                errorMessage: `O MessageBox apareceu, mas a mensagem não correspondeu a: "${mensagem}".`
                            });
						},
						errorMessage: `O MessageBox não apareceu com título '${titulo}' com mensagem '${mensagem}'.`
					});
				},
                deveMostrarMessageToast: function (mensagem) {
                    return this.waitFor({
                        pollingInterval: 200,
                        check: function () {
                            var elementosMessageToast = sap.ui.test.Opa5.getJQuery()(".sapMMessageToast");
                            var elementosEsperados = elementosMessageToast.filter(function (i, elemento) {
                                return elemento && elemento.textContent.trim() === mensagem;
                            });
                
                            return elementosEsperados.length > 0;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "MessageToast foi exibido com o texto: " + mensagem);
                        },
                        errorMessage: "MessageToast com o texto '" + mensagem + "' não foi encontrado."
                    });
                },
            }
        }
    });
});