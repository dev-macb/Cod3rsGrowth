sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/AggregationContainsPropertyEqual"
], function(Opa5, Press, EnterText, PropertyStrictEquals, AggregationLengthEquals, AggregationContainsPropertyEqual) {
    "use strict";

    const nomeDaView = "ListaPersonagem";

    Opa5.createPageObjects({
        naPaginaListaPersonagem: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        id: "__xmlview1--paginaListaPersonagem-navButton",
                        actions: new Press(),
                        errorMessage: "Botão de voltar não encontrado."
                    });
                },
                aoClicarEmCarregarMaisDadosDaLista: function() {
                    return this.waitFor({
                        id: "listaPersonagem",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível carregar mais dados da lista."
                    });
                },
                aoInserirFiltroNome: function(filtroNome) {
                    return this.waitFor({
                        id: "filtroNome",
                        viewName: nomeDaView,
                        actions: new EnterText({ text: filtroNome }),
                        errorMessage: "Campo de busca para filtrar por nome não encontrado."
                    });
                },
                aoClicarEmVerFiltros: function() {
                    return this.waitFor({
                        id: "btnFiltroPersonagem",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Ver Lista de Personagens' não encontrado."
                    });
                },
                aoSelecionarFiltroProposito: function() {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.StandardListItem",
                        matchers: new PropertyStrictEquals({ name: "title", value: "Propósito" }),
                        actions: function (item) {
							item.firePress();
						},
                        errorMessage: "Item 'Propósito' não encontrado na lista"
                    });
                },
                aoDefinirFiltroProposito: function(proposito) {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.StandardListItem",
                        matchers: new PropertyStrictEquals({ name: "title", value: proposito }),
                        actions: function(item) {
                            item.$().trigger("tap");
                        },
                        errorMessage: "Falha ao escolher o propósito para filtrar."
                    });
                },
                aoClicarEmAplicarFiltros: function() {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.Button",
                        check: function(aButtons) {
                            return aButtons.some(function(oButton) {
                                return oButton.getId().includes("dialogoFiltrosPersonagem-acceptbutton");
                            });
                        },
                        success: function(aButtons) {
                            var oButton = aButtons.find(function(oButton) {
                                return oButton.getId().includes("dialogoFiltrosPersonagem-acceptbutton");
                            });
                            if (oButton) {
                                oButton.firePress();
                            } else {
                                throw new Error("Botão 'Ok' não encontrado.");
                            }
                        },
                        errorMessage: "Botão 'Ok' não encontrado."
                    });
                }
            },
            assertions: {
                verificaUrlListaPersonagem: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "personagens", "Navegou para o endpoind da ListaPersonagem");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                verificaTituloListaPersonagem: function() {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: nomeDaView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Lista de Personagens" }),
                        success: function(pagina) {
                            Opa5.assert.ok(pagina, "O título da página está correto");
                        },
                        errorMessage: "Não foi possível navegar para a lista de personagens ou o título está incorreto"
                    });
                },
                verificaSeHaPaginacao: function() {
                    return this.waitFor({
                        id: "listaPersonagem",
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
							name: "items",
							length: 10
						}),
						success: function () {
							Opa5.assert.ok(true, "Mostrando lista com paginacao de 10 itens");
						},
						errorMessage: "Mais dados não foram carregados na lista."
					});
                },
                verificaSeMaisDadosForamCarregados: function() {
                    return this.waitFor({
						id: "listaPersonagem",
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 20
						}),
						success: function () {
							Opa5.assert.ok(true, "Mostrando lista completa com todos os 20 itens");
						},
						errorMessage: "Mais dados não foram carregados na lista."
					});
                },
                verificaSeBuscouComFiltroNome: function (filtroNome) {
                    function verificarSeListaIncluiItemComNome(lista) {
                        return lista.getItems().every(function (elemento) {
                            if (!elemento.getBindingContext()) {
                                return false;
                            }

                            var nomeItem = elemento.getBindingContext().getProperty("nome");
                            return nomeItem.includes(filtroNome);
                        });
                    }

                    return this.waitFor({
                        id: "listaPersonagem",
                        viewName: nomeDaView,
                        success: function (lista) {
                            var listaFiltrada = verificarSeListaIncluiItemComNome(lista);
                            Opa5.assert.ok(listaFiltrada, "A lista foi filtrada pelo nome: " + filtroNome);
                        },
                        errorMessage: "Erro ao filtrar por nome"
                    });
                },
                verificaParametroNomeNaURL: function(valor) {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.ok(hash.includes(valor), "O parâmetro '" + valor+ "' está presente na URL.");
                        },
                        errorMessage: "O parâmetro 'nome' não está presente na URL."
                    });
                },
                verificaSeListaHabilidadeSemDados: function() {
                    return this.waitFor({
						id: "listaPersonagem",
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 0
						}),
						success: function () {
							Opa5.assert.ok(true, "Mostrando lista vazia com 0 itens");
						},
						errorMessage: "A lista não está vazia"
					});
                },
                verificaSeBuscouComFiltroProposito: function(valorProposito) {
                    return this.waitFor({
                        controlType: "sap.m.List",
                        matchers: new AggregationContainsPropertyEqual({
                            aggregationName: "items",
                            propertyName: "eVilao", // Propriedade a ser verificada
                            propertyValue: valorProposito
                        }),
                        success: function(lista) {
                            Opa5.assert.ok(true, "Os resultados foram filtrados corretamente pelo propósito: " + (valorProposito ? "Vilão" : "Herói"));
                        },
                        errorMessage: "Os resultados não foram filtrados corretamente pelo propósito: " + (valorProposito ? "Vilão" : "Herói")
                    });
                }
            }
        }
    });
});
