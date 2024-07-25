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

    opaTest("Deve filtrar por nome 'Defesa'", (Given, When, Then) => {
        // Act
        When.naPaginaListaHabilidade.aoInserirFiltroNome("Defesa");

        // Assert
        Then.naPaginaListaHabilidade.verificaSeBuscouComFiltroNome("Defesa");
        Then.naPaginaListaHabilidade.verificaParametroNomeNaURL("nome=Defesa");
    });

    opaTest("Deve limpar filtragem por nome", (Given, When, Then) => {
        // Act
        When.naPaginaListaHabilidade.aoInserirFiltroNome("");

        // Assert
        Then.naPaginaListaHabilidade.verificaSeHaPaginacao();
        Then.naPaginaListaHabilidade.deveVerificarUrlListaHabilidade("");
    });

    opaTest("Deve filtrar por nome inexistente", (Given, When, Then) => {
        // Act
        When.naPaginaListaHabilidade.aoInserirFiltroNome("HabilidadeInexistente");

        // Assert
        Then.naPaginaListaHabilidade.verificaSeListaHabilidadeSemDados();
        Then.naPaginaListaHabilidade.verificaParametroNomeNaURL("nome=HabilidadeInexistente");
    });

    opaTest("Deve filtrar por data de criação", (Given, When, Then) => { 
        // Act
        When.naPaginaListaHabilidade.aoInserirFiltroNome("");
        When.naPaginaListaHabilidade.aoClicarEmVerFiltros();
        When.naPaginaListaHabilidade.aoSelecionarFiltroDataDeCriacao();
        When.naPaginaListaHabilidade.aoDefinirFiltroDataDeCriacao("2024-07-01", "2024-07-10");
        When.naPaginaListaHabilidade.aoClicarEmAplicarFiltros();

        // Assert
        Then.naPaginaListaHabilidade.verificaSeBuscouComFiltroDataDeCriacao();
    });
});