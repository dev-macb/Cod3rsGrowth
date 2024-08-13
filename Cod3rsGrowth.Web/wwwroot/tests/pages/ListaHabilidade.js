sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/AggregationLengthEquals"
], function(Opa5, Press, EnterText, PropertyStrictEquals, AggregationLengthEquals) {
    "use strict";

    const nomeDaView = "ListaHabilidade";
    const idListaHabilidade = "listaHabilidade";
    const idBotaoFiltroHabilidade = "btnFiltroHabilidade";
    const idFiltroNome = "filtroNome";
    const idBotaoVoltar = "__xmlview3--paginaListaHabilidade-navButton";

    Opa5.createPageObjects({
        naPaginaListaHabilidade: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        id: idBotaoVoltar,
                        actions: new Press(),
                        errorMessage: "Botão de voltar não encontrado."
                    });
                },
                aoClicarEmCarregarMaisDadosDaLista: function() {
                    return this.waitFor({
                        id: idListaHabilidade,
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível carregar mais dados da lista."
                    });
                },
                aoInserirFiltroNome: function(filtroNome) {
                    return this.waitFor({
                        id: idFiltroNome,
                        viewName: nomeDaView,
                        actions: new EnterText({ text: filtroNome }),
                        errorMessage: "Campo de busca para filtrar por nome não encontrado."
                    });
                },
                aoClicarEmVerFiltros: function() {
                    return this.waitFor({
                        id: idBotaoFiltroHabilidade,
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Ver Filtros' não encontrado."
                    });
                },
                aoSelecionarFiltroDataDeCriacao: function() {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.StandardListItem",
                        matchers: new PropertyStrictEquals({ name: "title", value: "Data de Criação" }),
                        actions: function(item) {
                            item.firePress();
                        },
                        errorMessage: "Filtro 'Data de Criação' não encontrado."
                    });
                },
                aoDefinirFiltroDataDeCriacao: function(dataBase, dataTeto) {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.ui.unified.Calendar",
                        success: function(aCalendars) {
                            var oCalendar = aCalendars[0];
                            oCalendar.removeAllSelectedDates();
                            oCalendar.addSelectedDate(new sap.ui.unified.DateRange({
                                startDate: new Date(dataBase),
                                endDate: new Date(dataTeto)
                            }));
                            oCalendar.fireSelect();
                        },
                        errorMessage: "Calendário para o filtro 'Data de Criação' não encontrado."
                    });
                },
                aoClicarEmAplicarFiltros: function() {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        controlType: "sap.m.Button",
                        check: function(aButtons) {
                            return aButtons.some(function(oButton) {
                                return oButton.getId().includes("dialogoFiltrosHabilidade-acceptbutton");
                            });
                        },
                        success: function(aButtons) {
                            var oButton = aButtons.find(function(oButton) {
                                return oButton.getId().includes("dialogoFiltrosHabilidade-acceptbutton");
                            });
                            if (oButton) {
                                oButton.firePress();
                            } else {
                                throw new Error("Botão 'Ok' não encontrado.");
                            }
                        },
                        errorMessage: "Botão 'Ok' não encontrado."
                    });
                },
            },
            assertions: {
                verificaUrl: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "habilidades", "A URL corresponde ao endpoint da lista de habilidades");
                        },
                        errorMessage: "A URL não é a esperada."
                    });
                },
                verificaTituloDaPagina: function (texto) {
                    return this.waitFor({
                        controlType: "sap.m.Title",
                        viewName: nomeDaView,
                        matchers: new PropertyStrictEquals({ name: "text", value: texto }),
                        success: function (pagina) {
                            Opa5.assert.ok(pagina, `Página ListaHabilidade tem título: ${texto}`);
                        },
                        errorMessage: `Página ListaHabilidade tem título: ${texto}`
                    });
                },
                verificaSeHaPaginacao: function() {
                    return this.waitFor({
                        id: idListaHabilidade,
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: 10
                        }),
                        success: function() {
                            Opa5.assert.ok(true, "Mostrando lista com paginação de 10 itens.");
                        },
                        errorMessage: "Mais dados não foram carregados na lista."
                    });
                },
                verificaSeMaisDadosForamCarregados: function() {
                    return this.waitFor({
                        id: idListaHabilidade,
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: 14
                        }),
                        success: function() {
                            Opa5.assert.ok(true, "Mostrando lista completa com todos os 14 itens.");
                        },
                        errorMessage: "Mais dados não foram carregados na lista."
                    });
                },
                verificaSeBuscouComFiltroNome: function(filtroNome) {
                    function verificarSeListaIncluiItemComNome(lista) {
                        return lista.getItems().every(function(elemento) {
                            if (!elemento.getBindingContext()) {
                                return false;
                            }

                            var nomeItem = elemento.getBindingContext().getProperty("nome");
                            return nomeItem.includes(filtroNome);
                        });
                    }

                    return this.waitFor({
                        id: idListaHabilidade,
                        viewName: nomeDaView,
                        success: function(lista) {
                            var listaFiltrada = verificarSeListaIncluiItemComNome(lista);
                            Opa5.assert.ok(listaFiltrada, "A lista foi filtrada pelo nome: " + filtroNome);
                        },
                        errorMessage: "Erro ao filtrar por nome."
                    });
                },
                verificaParametroNaURL: function(valor) {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.ok(hash.includes(valor), "O parâmetro '" + valor + "' está presente na URL.");
                        },
                        errorMessage: "O parâmetro não está presente na URL."
                    });
                },
                verificaSeListaHabilidadeSemDados: function() {
                    return this.waitFor({
                        id: idListaHabilidade,
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: 0
                        }),
                        success: function() {
                            Opa5.assert.ok(true, "Mostrando lista vazia com 0 itens.");
                        },
                        errorMessage: "A lista não está vazia."
                    });
                },
                verificaSeBuscouComFiltroDataDeCriacao: function(dataBase, dataTeto) {
                    function verificaDataDeCriacao(item) {
                        if (!item.getBindingContext()) {
                            return false;
                        }
                        var criadoEm = new Date(item.getBindingContext().getProperty("criadoEm"));
                        return criadoEm >= new Date(dataBase) && criadoEm <= new Date(dataTeto);
                    }

                    return this.waitFor({
                        id: idListaHabilidade,
                        viewName: nomeDaView,
                        matchers: function(list) {
                            return list.getItems().every(verificaDataDeCriacao);
                        },
                        success: function() {
                            Opa5.assert.ok(true, "A lista está filtrada corretamente por data de criação.");
                        },
                        errorMessage: "A lista não está filtrada corretamente por data de criação."
                    });
                },
            }
        }
    });
});