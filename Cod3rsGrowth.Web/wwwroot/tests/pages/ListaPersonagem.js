sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/matchers/BindingPath"
], function (Opa5, Press, EnterText, PropertyStrictEquals, AggregationLengthEquals, BindingPath) {
    "use strict";

    const nomeDaView = "ListaPersonagem";
    const idBotaoVoltar = "__xmlview1--paginaListaPersonagem-navButton";
    const idListaPersonagem = "listaPersonagem";
    const idFiltroNome = "filtroNome";
    const idBotaoFiltroPersonagem = "btnFiltroPersonagem";

    Opa5.createPageObjects({
        naPaginaListaPersonagem: {
            actions: {
                aoClicarNoBotaoVoltar: function () {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        id: idBotaoVoltar,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar."
                    });
                },
                aoClicarEmCarregarMaisDadosDaLista: function () {
                    return this.waitFor({
                        id: idListaPersonagem,
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível carregar mais dados na lista."
                    });
                },
                aoInserirFiltroNome: function (filtroNome) {
                    return this.waitFor({
                        id: idFiltroNome,
                        viewName: nomeDaView,
                        actions: new EnterText({ text: filtroNome }),
                        errorMessage: "Não foi possível encontrar o campo de busca para filtrar por nome."
                    });
                },
                aoClicarEmVerFiltros: function () {
                    return this.waitFor({
                        id: idBotaoFiltroPersonagem,
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão 'Ver Filtros'."
                    });
                },
                aoSelecionarFiltroProposito: function () {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.StandardListItem",
                        matchers: new PropertyStrictEquals({ name: "title", value: "Propósito" }),
                        actions: function (item) {
                            item.firePress();
                        },
                        errorMessage: "Não foi possível encontrar o filtro 'Propósito' na lista."
                    });
                },
                aoDefinirFiltroProposito: function (proposito) {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.StandardListItem",
                        matchers: new PropertyStrictEquals({ name: "title", value: proposito }),
                        actions: function (item) {
                            item.$().trigger("tap");
                        },
                        errorMessage: "Não foi possível definir o filtro de propósito '" + proposito + "'."
                    });
                },
                aoDefinirFiltroPropositoVilao: function () {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.StandardListItem",
                        matchers: new PropertyStrictEquals({ name: "title", value: "Vilão" }),
                        actions: function (item) {
                            item.$().trigger("tap");
                        },
                        errorMessage: "Não foi possível definir o filtro de propósito 'Vilão'."
                    });
                },
                aoClicarEmAplicarFiltros: function () {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.Button",
                        check: function (botoes) {
                            return botoes.some(function (botao) {
                                return botao.getId().includes("dialogoFiltrosPersonagem-acceptbutton");
                            });
                        },
                        success: function (botoes) {
                            var botao = botoes.find(function (botao) {
                                return botao.getId().includes("dialogoFiltrosPersonagem-acceptbutton");
                            });
                            if (botao) {
                                botao.firePress();
                            } 
                            else {
                                throw new Error("Não foi possível encontrar o botão 'OK' para aplicar os filtros.");
                            }
                        },
                        errorMessage: "Não foi possível encontrar o botão 'OK' para aplicar os filtros."
                    });
                },
                aoClicarEmResetarFiltros: function () {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.Button",
                        check: function (aButtons) {
                            return aButtons.some(function (oButton) {
                                return oButton.getId().includes("dialogoFiltrosPersonagem-detailresetbutton");
                            });
                        },
                        success: function (aButtons) {
                            var oButton = aButtons.find(function (oButton) {
                                return oButton.getId().includes("dialogoFiltrosPersonagem-detailresetbutton");
                            });
                            if (oButton) {
                                oButton.firePress();
                            } 
                            else {
                                throw new Error("Não foi possível encontrar o botão 'Resetar Filtros'.");
                            }
                        },
                        errorMessage: "Não foi possível encontrar o botão 'Resetar Filtros'."
                    });
                },
                aoSelecionarFiltroDataDeCriacao: function () {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.StandardListItem",
                        matchers: new PropertyStrictEquals({ name: "title", value: "Data de Criação" }),
                        actions: function (item) {
                            item.firePress();
                        },
                        errorMessage: "Não foi possível encontrar o filtro 'Data de Criação'."
                    });
                },
                aoDefinirFiltroDataDeCriacao: function (dataBase, dataTeto) {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.ui.unified.Calendar",
                        success: function (aCalendars) {
                            var oCalendar = aCalendars[0];
                            oCalendar.removeAllSelectedDates();
                            oCalendar.addSelectedDate(new sap.ui.unified.DateRange({
                                startDate: new Date(dataBase),
                                endDate: new Date(dataTeto)
                            }));
                            oCalendar.fireSelect();
                        },
                        errorMessage: "Não foi possível definir o filtro de data de criação."
                    });
                },
                aoClicarNaLista: function () {
					return this.waitFor({
						id: idListaPersonagem,
						viewName: nomeDaView,
						actions: new Press(),
						errorMessage: "Lista de personagens não encontrada"
					});
				},
                aoSelecionarItemDaLista: function (indice) {
                    return this.waitFor({
                        id: idListaPersonagem,
						viewName: nomeDaView,
                        success: function (oList) {
                            var oFirstItem = oList.getItems()[indice];
                            oFirstItem.$().trigger("tap");
                        },
                        errorMessage: "A lista de personagens não foi encontrada."
                    });
                }
            },
            assertions: {
                verificaUrlListaPersonagem: function () {
                    return this.waitFor({
                        success: function () {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "personagens", "A URL corresponde ao endpoint da lista de personagens.");
                        },
                        errorMessage: "A URL não é a esperada."
                    });
                },
                verificaTituloListaPersonagem: function () {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: nomeDaView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Lista de Personagens" }),
                        success: function (pagina) {
                            Opa5.assert.ok(pagina, "O título da página está correto.");
                        },
                        errorMessage: "Não foi possível verificar o título da página."
                    });
                },
                verificaSeHaPaginacao: function () {
                    return this.waitFor({
                        id: idListaPersonagem,
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: 10
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A lista está paginada com 10 itens.");
                        },
                        errorMessage: "A lista não está paginada corretamente."
                    });
                },
                verificaSeMaisDadosForamCarregados: function () {
                    return this.waitFor({
                        id: idListaPersonagem,
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: 20
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "Mais dados foram carregados na lista.");
                        },
                        errorMessage: "Não foi possível carregar mais dados na lista."
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
                        id: idListaPersonagem,
                        viewName: nomeDaView,
                        success: function (lista) {
                            var listaFiltrada = verificarSeListaIncluiItemComNome(lista);
                            Opa5.assert.ok(listaFiltrada, "A lista foi filtrada corretamente pelo nome: " + filtroNome);
                        },
                        errorMessage: "Erro ao filtrar a lista pelo nome."
                    });
                },
                verificaParametroNaURL: function (valor) {
                    return this.waitFor({
                        success: function () {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.ok(hash.includes(valor), "O parâmetro '" + valor + "' está presente na URL.");
                        },
                        errorMessage: "O parâmetro '" + valor + "' não está presente na URL."
                    });
                },
                verificaSeListaPersonagemSemDados: function () {
                    return this.waitFor({
                        id: idListaPersonagem,
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: 0
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A lista de personagens está vazia.");
                        },
                        errorMessage: "A lista de personagens não está vazia."
                    });
                },
                verificaSeBuscouComFiltroProposito: function (proposito) {
                    function verificaPropriedadeEVilao(item) {
                        if (!item.getBindingContext()) {
                            return false;
                        }
                        var eVilao = item.getBindingContext().getProperty("eVilao");
                        return eVilao === proposito;
                    }

                    return this.waitFor({
                        id: idListaPersonagem,
                        viewName: nomeDaView,
                        matchers: function (lista) {
                            return lista.getItems().every(verificaPropriedadeEVilao);
                        },
                        success: function () {
                            Opa5.assert.ok(true, "A lista está filtrada corretamente pelo propósito.");
                        },
                        errorMessage: "Erro ao filtrar a lista pelo propósito."
                    });
                },
                verificaSeBuscouComFiltroDataDeCriacao: function (dataBase, dataTeto) {
                    function verificaDataDeCriacao(item) {
                        if (!item.getBindingContext()) {
                            return false;
                        }
                        var criadoEm = new Date(item.getBindingContext().getProperty("criadoEm"));
                        return criadoEm >= new Date(dataBase) && criadoEm <= new Date(dataTeto);
                    }

                    return this.waitFor({
                        id: idListaPersonagem,
                        viewName: nomeDaView,
                        matchers: function (list) {
                            return list.getItems().every(verificaDataDeCriacao);
                        },
                        success: function () {
                            Opa5.assert.ok(true, "A lista está filtrada corretamente por data de criação.");
                        },
                        errorMessage: "Erro ao filtrar a lista por data de criação."
                    });
                }
            }
        }
    });
});
