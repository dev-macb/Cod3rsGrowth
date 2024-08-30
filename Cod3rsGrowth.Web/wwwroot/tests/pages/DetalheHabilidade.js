sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Ancestor",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals"
], function (Opa5, Press, Ancestor, Properties, PropertyStrictEquals) {
    "use strict";

    const nomeDaView = "DetalheHabilidade";

    Opa5.createPageObjects({
        naPaginaDetalheHabilidade: {
            actions: {
                aoClicarNoBotaoVoltar: function() {
                    return this.waitFor({
                        id: "botaoVoltar",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar."
                    });
                },
            },
            assertions: {    
                verificaUrl: function (idEsperado) {
                    return this.waitFor({
                        success: function () {
                            var hash = Opa5.getHashChanger().getHash();
                            Opa5.assert.strictEqual(hash, `habilidades/${idEsperado}`, `O hash da URL DetalheHabilidade é 'habilidades/${idEsperado}'`);
                        },
                        errorMessage: "A URL de detalhes da habilidade está incorreta."
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
                verificaDetalhesDaHabilidade: function () {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        check: function (textos) {
                            var idsRequeridos = ["txtDescricao", "txtDataCriacao", "txtDataAtualizacao"];
                            var todosCamposEncontrados = idsRequeridos.every(function (id) {
                                var texto = textos.find(function (texto) {
                                    return texto.getId().indexOf(id) !== -1;
                                });
                                return texto && texto.getText() !== "";
                            });
                            return todosCamposEncontrados;
                        },
                        success: function () {
                            Opa5.assert.ok(true, "Todos os campos do formulário da habilidade possuem dados");
                        },
                        errorMessage: "Alguns campos do formulário da habilidade não foram encontrados ou estão vazios"
                    });
                },
            }
        }
    });
});