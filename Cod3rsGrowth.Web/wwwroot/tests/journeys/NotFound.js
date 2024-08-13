sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/NotFound"
], (opaTest) => {
    "use strict";

    QUnit.module("NotFound");

    opaTest("Deve navegar para uma página inexistente", (Given, When, Then) => {
        // Arrange
        Given.iniciarAplicacao({ hash: "rota/que/nao/existe" });

        // Assert
        Then.naPaginaNotFound.verificaUrl();
        Then.naPaginaNotFound.verificaTituloPaginaNotFound();
    });

    opaTest("Deve retornar para Home ao clicar no botão voltar", (Given, When, Then) => {        
        // Act
        When.naPaginaNotFound.aoClicarEmVerVoltarHome();

        // Assert
        Then.naPaginaHome.verificaUrl();
        Then.naPaginaHome.verificaTituloPaginaHome();

        Then.iTeardownMyApp();
    });
});