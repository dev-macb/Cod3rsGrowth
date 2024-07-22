sap.ui.define([
    "sap/ui/test/opaQunit",
    "./pages/Home",
    "./pages/ListaPersonagem",
    "./pages/ListaHabilidade"
], (opaTest) => {
    "use strict";

    QUnit.module("Navigation");

    opaTest("Deve navegar para a listagem de personagens", (Given, When, Then) => {
        // Arrange
        Given.iStartMyUIComponent({ componentConfig: { name: "coders-growth" } });

        // Act
        When.naPaginaHome.aoClicarEmVerListaPersonagem();

        // Assert
        Then.naListaPersonagem.deveVerificarUrlPersonagens();
        Then.naListaPersonagem.deveVerificarTituloListaPersonagem();

        When.naListaPersonagem.aoClicarNoBotaoVoltar();
        Then.iTeardownMyApp();
    });

    opaTest("Deve navegar para a listagem de habilidades", (Given, When, Then) => {
        // Arrange
        Given.iStartMyUIComponent({ componentConfig: { name: "coders-growth" } });

        // Act
        When.naPaginaHome.aoClicarEmVerListaHabilidade();

        // Assert
        Then.naListaHabilidade.deveVerificarUrlHabilidades();
        Then.naListaHabilidade.deveVerificarTituloListaHabilidade();

        When.naListaHabilidade.aoClicarNoBotaoVoltar();
        Then.iTeardownMyApp();
    });
});