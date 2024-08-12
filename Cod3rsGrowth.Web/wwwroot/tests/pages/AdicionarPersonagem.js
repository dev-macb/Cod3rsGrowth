sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/AggregationFilled",
], (Opa5, Press, EnterText, PropertyStrictEquals, AggregationFilled) => {
    "use strict";

    Opa5.createPageObjects({
        noFormularioPersonagem: {
            actions: {
                aoInserirNome: function (nome) {
                    return this.waitFor({
                        id: "inputNome",
                        actions: new EnterText({ text: nome }),
                        errorMessage: "Campo 'Nome' não encontrado ou não editável."
                    });
                },

                aoInserirVida: function (vida) {
                    return this.waitFor({
                        id: "inputVida",
                        actions: new EnterText({ text: vida.toString() }),
                        errorMessage: "Campo 'Vida' não encontrado ou não editável."
                    });
                },

                aoInserirEnergia: function (energia) {
                    return this.waitFor({
                        id: "inputEnergia",
                        actions: new EnterText({ text: energia.toString() }),
                        errorMessage: "Campo 'Energia' não encontrado ou não editável."
                    });
                },

                aoInserirVelocidade: function (velocidade) {
                    return this.waitFor({
                        id: "inputVelocidade",
                        actions: new EnterText({ text: velocidade.toString() }),
                        errorMessage: "Campo 'Velocidade' não encontrado ou não editável."
                    });
                },

                aoSelecionarForca: function (forca) {
                    return this.waitFor({
                        id: "comboForca",
                        actions: new Press(),
                        success: function (comboBox) {
                            comboBox.setSelectedKey(forca);
                            Opa5.assert.strictEqual(comboBox.getSelectedKey(), forca.toString(), "Força selecionada corretamente.");
                        },
                        errorMessage: "ComboBox 'Força' não encontrado ou não selecionável."
                    });
                },

                aoSelecionarInteligencia: function (inteligencia) {
                    return this.waitFor({
                        id: "comboInteligencia",
                        actions: new Press(),
                        success: function (comboBox) {
                            comboBox.setSelectedKey(inteligencia);
                            Opa5.assert.strictEqual(comboBox.getSelectedKey(), inteligencia.toString(), "Inteligência selecionada corretamente.");
                        },
                        errorMessage: "ComboBox 'Inteligência' não encontrado ou não selecionável."
                    });
                },

                aoDefinirEVilao: function (eVilao) {
                    return this.waitFor({
                        id: eVilao ? "radioVilao" : "radioHeroi",
                        actions: new Press(),
                        success: function () {
                            Opa5.assert.ok(true, "Opção de vilão/herói selecionada corretamente.");
                        },
                        errorMessage: "Opção de vilão/herói não encontrada ou não selecionável."
                    });
                },

                aoDefinirHabilidades: function (listaHabilidades) {
                    return this.waitFor({
                        id: "listaHabilidadeSelecionadas",
                        matchers: new AggregationFilled({ name: "items" }),
                        success: function (lista) {
                            listaHabilidades.forEach((indice) => {
                                const item = lista.getItems()[indice];
                                if (item) {
                                    item.setSelected(true);
                                    Opa5.assert.ok(item.getSelected(), "Habilidade selecionada corretamente.");
                                } else {
                                    Opa5.assert.ok(false, "Habilidade com índice " + indice + " não encontrada.");
                                }
                            });
                        },
                        errorMessage: "Lista de habilidades não encontrada, sem itens ou índice inválido."
                    });
                },

                aoClicarNoBotaoSalvar: function () {
                    return this.waitFor({
                        id: "paginaAdicionarPersonagem--btnSalvar",
                        actions: new Press(),
                        errorMessage: "Botão de salvar não encontrado ou não clicável."
                    });
                }
            },

            assertions: {
                deveMostrarMessageToastComMensagem: function (mensagem) {
                    return this.waitFor({
                        check: function () {
                            const toast = sap.ui.test.Opa5.getJQuery()(".sapMMessageToast:visible");
                            return toast.length > 0 && toast.text() === mensagem;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "Mensagem de sucesso exibida com o texto correto.");
                        },
                        errorMessage: "Mensagem de sucesso não foi exibida ou texto incorreto."
                    });
                }
            }
        }
    });
});
