sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem"
], (opaTest) => {
    "use strict";

    QUnit.module("ListaPersonagem");

    opaTest("Deve carregar mais itens da listagem", (Given, When, Then) => {
        // Arrange
        Given.iniciarAplicacao();
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
        Then.naPaginaListaPersonagem.verificaParametroNaURL("nome=Ryu");
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
        Then.naPaginaListaPersonagem.verificaSeListaPersonagemSemDados();
        Then.naPaginaListaPersonagem.verificaParametroNaURL("nome=HabilidadeInexistente");
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
        Then.naPaginaListaPersonagem.verificaParametroNaURL("evilao=false");
        Then.naPaginaListaPersonagem.verificaSeBuscouComFiltroProposito(false);
    });

    opaTest("Deve filtrar por propósito vilanesco", (Given, When, Then) => { 
        // Act
        When.naPaginaListaPersonagem.aoClicarEmVerFiltros();
        When.naPaginaListaPersonagem.aoDefinirFiltroProposito("Vilão");
        When.naPaginaListaPersonagem.aoClicarEmAplicarFiltros();

        // Assert
        Then.naPaginaListaPersonagem.verificaParametroNaURL("evilao=true");
        Then.naPaginaListaPersonagem.verificaSeBuscouComFiltroProposito(true);
    });

    opaTest("Deve resetar os filtros", (Given, When, Then) => { 
        // Act
        When.naPaginaListaPersonagem.aoClicarEmVerFiltros();
        When.naPaginaListaPersonagem.aoClicarEmResetarFiltros();
        When.naPaginaListaPersonagem.aoClicarEmAplicarFiltros();

        // Assert
        Then.naPaginaListaPersonagem.verificaParametroNaURL("");
    });

    opaTest("Deve filtrar por data de criação", (Given, When, Then) => { 
        // Act
        When.naPaginaListaPersonagem.aoClicarEmVerFiltros();
        When.naPaginaListaPersonagem.aoSelecionarFiltroDataDeCriacao();
        When.naPaginaListaPersonagem.aoDefinirFiltroDataDeCriacao("2024-07-28", "2024-07-30");
        When.naPaginaListaPersonagem.aoClicarEmAplicarFiltros();

        // Assert
        Then.naPaginaListaPersonagem.verificaSeBuscouComFiltroDataDeCriacao("2024-07-28", "2024-07-30");
        Then.naPaginaListaPersonagem.verificaParametroNaURL("database=2024-07-27T21:00:00Z&datateto=2024-07-29T21:00:00Z");
        Then.iTeardownMyApp();
    });
});