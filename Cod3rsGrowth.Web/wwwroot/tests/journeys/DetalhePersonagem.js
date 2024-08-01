sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem",
    "../pages/DetalhePersonagem",
], (opaTest) => {
    "use strict";

    QUnit.module("DetalhePersonagem");

    opaTest("Deve navegar para a listagem de personagens", (Given, When, Then) => {
        // Arrange
        Given.iStartMyApp();
        When.naPaginaHome.aoClicarEmVerListaPersonagem();

        // Act
        When.naPaginaListaPersonagem.aoClicarNaLista();
        When.naPaginaListaPersonagem.aoSelecionarItemDaLista(1);

        // Assert
        Then.naPaginaDetalhePersonagem.verificaDetalhesDoPersonagem();
        Then.naPaginaDetalhePersonagem.verificaUrlDetalhePersonagem();
        Then.naPaginaDetalhePersonagem.verificaTituloListaPersonagem();
        Then.iTeardownMyApp();
    });
});