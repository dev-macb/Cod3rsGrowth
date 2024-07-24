sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem",
    "../pages/ListaHabilidade"
], (opaTest) => {
    "use strict";

    QUnit.module("Home");

    opaTest("Deve navegar para a listagem de personagens", (Given, When, Then) => {
        // Arrange
        Given.iStartMyApp();

        // Act
        When.naPaginaHome.aoClicarEmVerListaPersonagem();

        // Assert
        Then.naPaginaListaPersonagem.deveVerificarUrlListaPersonagem();
        Then.naPaginaListaPersonagem.deveVerificarTituloListaPersonagem();
        
        Then.iTeardownMyApp();
    });

    opaTest("Deve navegar para a listagem de habilidades", (Given, When, Then) => {
        // Arrange
        Given.iStartMyApp();
        
        // Act
        When.naPaginaHome.aoClicarEmVerListaHabilidade();

        // Assert
        Then.naPaginaListaHabilidade.deveVerificarUrlListaHabilidade();
        Then.naPaginaListaHabilidade.deveVerificarTituloListaHabilidade();

        Then.iTeardownMyApp();
    });
});