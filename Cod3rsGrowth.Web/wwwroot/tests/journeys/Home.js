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
        Then.naPaginaListaPersonagem.verificaUrlListaPersonagem();
        Then.naPaginaListaPersonagem.verificaTituloListaPersonagem();
        Then.iTeardownMyApp();
    });

    opaTest("Deve navegar para a listagem de habilidades", (Given, When, Then) => {
        // Arrange
        Given.iStartMyApp();
        
        // Act
        When.naPaginaHome.aoClicarEmVerListaHabilidade();

        // Assert
        Then.naPaginaListaHabilidade.verificaUrlListaHabilidade();
        Then.naPaginaListaHabilidade.verificaTituloListaHabilidade();
        Then.iTeardownMyApp();
    });
});