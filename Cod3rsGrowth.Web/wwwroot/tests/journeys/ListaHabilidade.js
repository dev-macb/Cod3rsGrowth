sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/ListaPersonagem",
    "../pages/ListaHabilidade"
], (opaTest) => {
    "use strict";

    QUnit.module("ListaHabilidade");

    opaTest("Deve carregar mais itens da listagem de habilidades", (Given, When, Then) => {
        // Arrange
        Given.iniciarAplicacao({ hash: "habilidades" });

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
        Then.naPaginaListaHabilidade.verificaParametroNaURL("nome=Defesa");
    });

    opaTest("Deve limpar filtragem por nome", (Given, When, Then) => {
        // Act
        When.naPaginaListaHabilidade.aoInserirFiltroNome("");

        // Assert
        Then.naPaginaListaHabilidade.verificaSeHaPaginacao();
        Then.naPaginaListaHabilidade.verificaUrl();
    });

    opaTest("Deve filtrar por nome inexistente", (Given, When, Then) => {
        // Act
        When.naPaginaListaHabilidade.aoInserirFiltroNome("HabilidadeInexistente");

        // Assert
        Then.naPaginaListaHabilidade.verificaSeListaHabilidadeSemDados();
        Then.naPaginaListaHabilidade.verificaParametroNaURL("nome=HabilidadeInexistente");
    });

    opaTest("Deve filtrar por data de criação", (Given, When, Then) => { 
        // Arrange
        When.naPaginaListaHabilidade.aoInserirFiltroNome("");

        // Act
        When.naPaginaListaHabilidade.aoClicarEmVerFiltros();
        When.naPaginaListaHabilidade.aoSelecionarFiltroDataDeCriacao();
        When.naPaginaListaHabilidade.aoDefinirFiltroDataDeCriacao("2024-07-25", "2024-07-27");
        When.naPaginaListaHabilidade.aoClicarEmAplicarFiltros();

        // Assert
        Then.naPaginaListaHabilidade.verificaSeBuscouComFiltroDataDeCriacao("2024-07-25", "2024-07-27");
        Then.naPaginaListaHabilidade.verificaParametroNaURL("database=2024-07-24T21:00:00Z&datateto=2024-07-26T21:00:00Z");
        Then.iTeardownMyApp();
    });
});