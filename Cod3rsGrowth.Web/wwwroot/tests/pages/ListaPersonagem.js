sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/matchers/AggregationLengthEquals"
], function(Opa5, Press, PropertyStrictEquals, AggregationLengthEquals) {
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
            },
            
            assertions: {
                deveVerificarUrlListaPersonagem: function() {
                    return this.waitFor({
                        success: function() {
                            const hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, "personagens", "Navegou para o endpoind da ListaPersonagem");
                        },
                        errorMessage: "A URL não é a esperada"
                    });
                },
                deveVerificarTituloListaPersonagem: function() {
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
							Opa5.assert.ok(true, "Mostrando lista completa com todos os 13 itens");
						},
						errorMessage: "Mais dados não foram carregados na lista."
					});
                },
            }
        }
    });
});
