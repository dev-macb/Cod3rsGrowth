sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/ListaPersonagem",
    "../pages/ListaHabilidade"
], (opaTest) => {
    "use strict";

    QUnit.module("ListaHabilidade");

    opaTest("Deve carregar mais itens da listagem de habilidades", (Given, When, Then) => {
        // Arrange
        Given.iStartMyApp();
        When.naPaginaHome.aoClicarEmVerListaHabilidade();

        // Act
        Then.naPaginaListaHabilidade.verificaSeHaPaginacao();
        When.naPaginaListaHabilidade.aoClicarEmCarregarMaisDadosDaLista();

        // Assert
        Then.naPaginaListaHabilidade.verificaSeMaisDadosForamCarregados();
    });

    opaTest("Deve filtrar listagem de habilidade por nome", (Given, When, Then) => {
        // Act
        When.naPaginaListaHabilidade.aoInserirFiltroNome("Defesa");

        // Assert
        Then.naPaginaListaHabilidade.verificaSeBuscouComFiltroNome("Defesa");
        Then.naPaginaListaHabilidade.verificaParametroNomeNaURL();
    });

    opaTest("Deve limpar filtragem por nome", (Given, When, Then) => {
        // Act
        When.naPaginaListaHabilidade.aoInserirFiltroNome("");

        // Assert
        Then.naPaginaListaHabilidade.verificaSeHaPaginacao();
        Then.naPaginaListaHabilidade.deveVerificarUrlListaHabilidade();
        Then.iTeardownMyApp();
    });
});