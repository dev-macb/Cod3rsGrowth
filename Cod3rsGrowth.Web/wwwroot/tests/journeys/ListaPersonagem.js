sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem"
], (opaTest) => {
    "use strict";

    QUnit.module("ListaPersonagem");

    opaTest("Deve carregar mais itens da listagem", (Given, When, Then) => {
        // Arrange
        Given.iStartMyApp();
        When.naPaginaHome.aoClicarEmVerListaPersonagem();

        // Act
        Then.naPaginaListaPersonagem.verificaSeHaPaginacao();
        When.naPaginaListaPersonagem.aoClicarEmCarregarMaisDadosDaLista();

        // Assert
        Then.naPaginaListaPersonagem.verificaSeMaisDadosForamCarregados();
        Then.iTeardownMyApp();
    });
});