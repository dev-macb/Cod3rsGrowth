sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem"
], (opaTest) => {
    "use strict";

    QUnit.module("ListaPersonagem");

    opaTest("Deve carregar mais itens da listagem", (Given, When, Then) => {
        // Arrange
        Given.iStartMyApp();
        When.naPaginaHome.aoClicarEmVerListaPersonagem();

        // Act
        Then.naPaginaListaPersonagem.verificaSeHaPaginacao();
        When.naPaginaListaPersonagem.aoClicarEmCarregarMaisDadosDaLista();

        // Assert
        Then.naPaginaListaPersonagem.verificaSeMaisDadosForamCarregados();
    });

    opaTest("Deve filtrar por nome 'Ryu'", (Given, When, Then) => {
        // Act
        When.naPaginaListaPersonagem.aoInserirFiltroNome("Ryu");

        // Assert
        Then.naPaginaListaPersonagem.verificaSeBuscouComFiltroNome("Ryu");
        Then.naPaginaListaPersonagem.verificaParametroNomeNaURL("nome=Ryu");
    });

    opaTest("Deve limpar filtragem por nome", (Given, When, Then) => {
        // Act
        When.naPaginaListaPersonagem.aoInserirFiltroNome("");

        // Assert
        Then.naPaginaListaPersonagem.verificaSeHaPaginacao();
        Then.naPaginaListaPersonagem.verificaUrlListaPersonagem("");
    });

    opaTest("Deve filtrar por nome inexistente", (Given, When, Then) => {
        // Act
        When.naPaginaListaPersonagem.aoInserirFiltroNome("HabilidadeInexistente");

        // Assert
        Then.naPaginaListaPersonagem.verificaSeListaHabilidadeSemDados();
        Then.naPaginaListaPersonagem.verificaParametroNomeNaURL("nome=HabilidadeInexistente");
    });

    opaTest("Deve filtrar por propósito heroico", (Given, When, Then) => { 
        // Arrange
        When.naPaginaListaPersonagem.aoInserirFiltroNome("");

        // Act
        When.naPaginaListaPersonagem.aoClicarEmVerFiltros();
        When.naPaginaListaPersonagem.aoSelecionarFiltroProposito();
        When.naPaginaListaPersonagem.aoDefinirFiltroProposito("Herói");
        When.naPaginaListaPersonagem.aoClicarEmAplicarFiltros();

        // Assert
        Then.naPaginaListaPersonagem.verificaParametroNomeNaURL("evilao=false");
        // Then.naPaginaListaPersonagem.verificaSeBuscouComFiltroProposito(false);
    });

    opaTest("Deve filtrar por propósito vilanesco", (Given, When, Then) => { 
        // Arrange
        When.naPaginaListaPersonagem.aoInserirFiltroNome("");

        // Act
        When.naPaginaListaPersonagem.aoClicarEmVerFiltros();
        When.naPaginaListaPersonagem.aoSelecionarFiltroProposito();
        When.naPaginaListaPersonagem.aoDefinirFiltroProposito("Vilão");
        When.naPaginaListaPersonagem.aoClicarEmAplicarFiltros();

        // Assert
        Then.naPaginaListaPersonagem.verificaParametroNomeNaURL("evilao=true");
        // Then.naPaginaListaPersonagem.verificaSeBuscouComFiltroProposito(false);
        Then.iTeardownMyApp();
    });
});