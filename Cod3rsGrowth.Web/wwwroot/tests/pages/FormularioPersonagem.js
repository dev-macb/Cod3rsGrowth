sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Ancestor",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/Properties",
    ], (Opa5, Press, Ancestor, EnterText, Properties) => {
    "use strict";

    const nomeDaView = "FormularioPersonagem";

    Opa5.createPageObjects({
        noFormularioPersonagem: {
            actions: {
                aoClicarNoBotaoVoltar: function () {
                    return this.waitFor({
                        id: "botaoVoltar",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar."
                    });
                },

                aoClicarNoBotaoSalvar: function () {
                    return this.waitFor({
                        id: "butaoSalvarPersonagem",
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

                aoInserirVida: function (vida) {
                    return this.waitFor({
                        id: "inputVida",
                        viewName: nomeDaView,
                        actions: new EnterText({ text: vida.toString() }),
                        errorMessage: "Campo 'Vida' não encontrado ou não editável."
                    });
                },

                aoInserirEnergia: function (energia) {
                    return this.waitFor({
                        id: "inputEnergia",
                        viewName: nomeDaView,
                        actions: new EnterText({ text: energia.toString() }),
                        errorMessage: "Campo 'Energia' não encontrado ou não editável."
                    });
                },

                aoInserirVelocidade: function (velocidade) {
                    return this.waitFor({
                        id: "inputVelocidade",
                        viewName: nomeDaView,
                        actions: new EnterText({ text: velocidade.toString() }),
                        errorMessage: "Campo 'Velocidade' não encontrado ou não editável."
                    });
                },

                aoSelecionarForca: function (forca) {
                    return this.waitFor({
                        id: "comboForca",
                        viewName: nomeDaView,
                        actions: new Press(),
                        success: function (comboBox) {
                            comboBox.setSelectedKey(forca);
                        },
                        errorMessage: "ComboBox 'Força' não encontrado ou não selecionável."
                    });
                },

                aoSelecionarInteligencia: function (inteligencia) {
                    return this.waitFor({
                        id: "comboInteligencia",
                        viewName: nomeDaView,
                        actions: new Press(),
                        success: function (comboBox) {
                            comboBox.setSelectedKey(inteligencia);
                        },
                        errorMessage: "ComboBox 'Inteligência' não encontrado ou não selecionável."
                    });
                },

                aoDefinirEVilao: function (eVilao) {
                    return this.waitFor({
                        id: eVilao ? "radioVilao" : "radioHeroi",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Opção de vilão/herói não encontrada ou não selecionável."
                    });
                },

                aoDefinirHabilidades: function (listaHabilidades) {
                    return this.waitFor({
                        id: "listaHabilidadeSelecionadas",
                        viewName: nomeDaView,
                        success: function (lista) {
                            lista.removeSelections()
                            listaHabilidades.forEach((indice) => {
                                console.log(indice)
                                lista.getItems()[indice].setSelected(true);
                            });
                        },
                        errorMessage: "Lista de habilidades não encontrada ou sem itens."
                    });
                }
            },
            assertions: {
                verificaTipoDoInput: function (idInput, tipo) {
                    this.waitFor({
                        id: idInput,
                        viewName: nomeDaView,
                        success: function (input) {
                            const estadoValor = input.getValueState();
                            Opa5.assert.strictEqual(
                                estadoValor,
                                tipo,
                                `O input '${idInput}' está corretamente com o ValueState '${tipo}'.`
                            );
                        },
                        errorMessage: `O input com id '${idInput}' não foi encontrado ou não possui um ValueState '${tipo}'.`
                    });
                },
                verificaTipoDosInputs: function (tipo) {
                    const idsDosInputs = ["inputNome", "inputVida", "inputEnergia", "inputVelocidade", "comboForca", "comboInteligencia"];
                    
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
                
                deveNavegarParaDetalhesDoPersonagem: function () {
                    return this.waitFor({
                        success: function () {
                            const oHashChanger = Opa5.getHashChanger();
                            const sCurrentHash = oHashChanger.getHash();
                            const bCorreto = /personagens\/\d+/.test(sCurrentHash);
                            
                            Opa5.assert.ok(bCorreto, `Redirecionado corretamente para: '${sCurrentHash}'`);
                        },
                        errorMessage: "Navegação para a página de detalhes do personagem falhou."
                    });
                }
            }
        }
    });
});
