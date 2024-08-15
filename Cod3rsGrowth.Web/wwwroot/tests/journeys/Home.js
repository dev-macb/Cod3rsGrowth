sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/AggregationLengthEquals",
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem",
    "../pages/ListaHabilidade"
], (Opa5, AggregationLengthEquals, opaTest) => {
    "use strict";

    QUnit.module("Home");

    // opaTest("Deve navegar para a listagem de personagens", (Given, When, Then) => {
    //     // Arrange
    //     Given.iniciarAplicacao({ hash: "" });

    //     // Act
    //     When.naPaginaHome.aoClicarEmVerListaPersonagem();

    //     // Assert
    //     Then.naPaginaListaPersonagem.verificaUrl();
    //     Then.naPaginaListaPersonagem.verificaTituloDaPagina("Lista de Personagens");
    //     Then.iTeardownMyApp();
    // });

    // opaTest("Deve navegar para a listagem de habilidades", (Given, When, Then) => {
    //     // Arrange
    //     Given.iniciarAplicacao({ hash: "" });
        
    //     // Act
    //     When.naPaginaHome.aoClicarEmVerListaHabilidade();

    //     // Assert
    //     Then.naPaginaListaHabilidade.verificaUrl();
    //     Then.naPaginaListaHabilidade.verificaTituloDaPagina("Lista de Habilidades");
    //     Then.iTeardownMyApp();
    // });

    opaTest("TESTE MOCK: Verifica se a listagem possui só um item", function(Given, When, Then) {
        Given.iniciarAplicacao({ hash: "personagens" });
        
        Then.naPaginaListaPersonagem.verificaTamanhoDaLista(1);
    });
});