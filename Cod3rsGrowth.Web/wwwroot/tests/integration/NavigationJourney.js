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
        console.log("INICIO TESTE 2");
        // Arrange
        Given.iStartMyUIComponent({ componentConfig: { name: "coders-growth" } });

        // Act
        console.log("Clicar - Ver Lista Habilidade");
        When.naPaginaHome.aoClicarEmVerListaHabilidade();
        console.log("Clicado");

        // Assert
        Then.naListaHabilidade.deveVerificarUrlHabilidades();
        Then.naListaHabilidade.deveVerificarTituloListaHabilidade();
    });
});