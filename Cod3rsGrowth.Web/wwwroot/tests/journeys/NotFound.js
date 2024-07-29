sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/NotFound"
], (opaTest) => {
    "use strict";

    QUnit.module("NotFound");

    opaTest("Deve navegar para uma página inexistente", (Given, When, Then) => {
        // Arrange
        Given.iStartMyApp();

        // Act
        When.naPaginaHome.aoNavegarParaRotaInexistente();

        // Assert
        Then.naPaginaNotFound.verificaUrlPaginaNotFound();
        Then.naPaginaNotFound.verificaTituloPaginaNotFound();
    });

    opaTest("Deve retornar para Home ao clicar no botão voltar", (Given, When, Then) => {        
        // Act
        When.naPaginaNotFound.aoClicarEmVerVoltarHome();

        // Assert
        Then.naPaginaHome.verificaUrlPaginaHome();
        Then.naPaginaHome.verificaTituloPaginaHome();

        Then.iTeardownMyApp();
    });
});