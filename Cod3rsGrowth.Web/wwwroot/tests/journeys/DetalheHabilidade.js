sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/ListaHabilidade",
    "../pages/DetalheHabilidade",
], (opaTest) => {
    "use strict";

    QUnit.module("DetalheHabilidade");

    opaTest("Deve navegar para os detalhes de uma habilidade", (Given, When, Then) => {
        // Arrange
        let idHabilidade = 1;
        Given.iniciarAplicacao({ hash: `habilidades/${idHabilidade}` });

        // Assert
        Then.naPaginaDetalheHabilidade.verificaUrl(idHabilidade);
        Then.naPaginaDetalheHabilidade.verificaTituloDaPagina("Detalhes da Habilidade");
        Then.naPaginaDetalheHabilidade.verificaDetalhesDaHabilidade();
    });

    opaTest("Deve navegar de volta para a tela de listagem ao clicar no botão voltar", (Given, When, Then) => {
        // Act
        When.naPaginaDetalheHabilidade.aoClicarNoBotaoVoltar();

        // Assert
        Then.naPaginaListaHabilidade.verificaUrl();
        Then.naPaginaListaHabilidade.verificaTituloDaPagina("Lista de Habilidades");
        Then.iTeardownMyApp();
    });
});