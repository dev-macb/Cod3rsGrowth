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
                verificaParametroNomeNaURL: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.ok(hash.includes("nome=Defesa"), "O parâmetro 'nome' está presente na URL.");
                        },
                        errorMessage: "O parâmetro 'nome' não está presente na URL."
                    });
                }
            }
        }
    });
});