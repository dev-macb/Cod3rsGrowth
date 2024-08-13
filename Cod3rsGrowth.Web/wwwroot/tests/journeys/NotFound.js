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
        Then.naPaginaNotFound.verificaPropriedadesDaPagina();
    });

    opaTest("Deve retornar para Home ao clicar no botão voltar", (Given, When, Then) => {        
        // Act
        When.naPaginaNotFound.aoClicarEmVerVoltar();

        // Assert
        Then.naPaginaHome.verificaUrl();
        Then.naPaginaHome.verificaTituloDaPagina("Coder's Growth");
        Then.naPaginaHome.verificaTituloDoPainel("Glossário do Street Fighter");        
        Then.iTeardownMyApp();
    });
});