sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/AggregationLengthEquals"
], function(Opa5, Press, EnterText, PropertyStrictEquals, AggregationLengthEquals) {
    "use strict";

    const nomeDaView = "ListaHabilidade";

    Opa5.createPageObjects({
        naPaginaListaHabilidade: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        id: "__xmlview3--paginaListaHabilidade-navButton",
                        actions: new Press(),
                        errorMessage: "Botão de voltar não encontrado."
                    });
                },
                aoClicarEmCarregarMaisDadosDaLista: function() {
                    return this.waitFor({
                        id: "listaHabilidade",
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
                        id: "btnFiltroHabilidade",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Ver Lista de Personagens' não encontrado."
                    });
                },
                aoSelecionarFiltroDataDeCriacao: function() {
                    return this.waitFor({
                        id: "__xmlview1--filtroDataDeCriacao-list-item",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Filtro 'Data de Criação' não encontrado."
                    });
                },
                aoDefinirFiltroDataDeCriacao: function(dataBase, dataTeto) {
                    return this.waitFor({
                        controlType: "sap.m.ViewSettingsDialog",
                        matchers: new sap.ui.test.matchers.PropertyStrictEquals({ name: "id", value: "__xmlview1--dialogoFiltrosHabilidade" }),
                        success: function(aDialogs) {
                            var oDialog = aDialogs[0];
                            return this.waitFor({
                                controlType: "sap.ui.unified.Calendar",
                                matchers: new sap.ui.test.matchers.Ancestor(oDialog),
                                success: function(calendarios) {
                                    var calendario = calendarios[0];
                                    var oBaseDate = new Date(dataBase);
                                    var oTetoDate = new Date(dataTeto);
                                    
                                    calendario.removeAllSelectedDates();
                                    calendario.addSelectedDate(new sap.ui.unified.DateRange({ startDate: oBaseDate, endDate: oTetoDate }));
                                    Opa5.assert.ok(true, "Datas definidas no calendário: " + oBaseDate.toDateString() + " - " + oTetoDate.toDateString());
                                },
                                errorMessage: "Calendário para o filtro 'Data de Criação' não encontrado."
                            });
                        },
                        errorMessage: "Diálogo de filtros de habilidade não encontrado."
                    });
                },
                aoClicarEmAplicarFiltros: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        id: "__xmlview1--dialogoFiltrosHabilidade-acceptbutton",
                        actions: new Press(),
                        errorMessage: "Botão 'Ok' não encontrado no dialogo de filtros."
                    });
                }
            },
            assertions: {
                deveVerificarUrlListaHabilidade: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "habilidades", "Navegou para o endpoind da ListaHabilidade");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                deveVerificarTituloListaHabilidade: function() {
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        viewName: nomeDaView,
                        matchers: new PropertyStrictEquals({ name: "title", value: "Lista de Habilidades" }),
                        success: function(pagina) {
                            Opa5.assert.ok(pagina, "O título da página está correto");
                        },
                        errorMessage: "Não foi possível navegar para a lista de habilidades ou o título está incorreto"
                    });
                },
                verificaSeHaPaginacao: function() {
                    return this.waitFor({
                        id: "listaHabilidade",
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
						id: "listaHabilidade",
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 13
						}),
						success: function () {
							Opa5.assert.ok(true, "Mostrando lista completa com todos os 13 itens");
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
                        id: "listaHabilidade",
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
						id: "listaHabilidade",
						viewName: nomeDaView,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: 0
						}),
						success: function () {
							Opa5.assert.ok(true, "Mostrando lista completa com todos os 13 itens");
						},
						errorMessage: "Mais dados não foram carregados na lista."
					});
                },
                verificaSeBuscouComFiltroDataDeCriacao: function(dataBase, dataTeto) {
                    return this.waitFor({
                        id: "listaHabilidade",
                        viewName: nomeDaView,
                        success: function(oList) {
                            var bFiltroAplicado = oList.getItems().every(function(oItem) {
                                var oBindingContext = oItem.getBindingContext();
                                if (!oBindingContext) {
                                    return false;
                                }
                                var dataCriacao = oBindingContext.getProperty("dataCriacao");
                                return (new Date(dataCriacao) >= new Date(dataBase)) && (new Date(dataCriacao) <= new Date(dataTeto));
                            });
                            Opa5.assert.ok(bFiltroAplicado, "A lista foi filtrada pela data de criação entre " + dataBase + " e " + dataTeto);
                        },
                        errorMessage: "Erro ao verificar a filtragem por data de criação"
                    });
                }
            }
        }
    });
});