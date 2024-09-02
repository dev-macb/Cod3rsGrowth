sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem",
    "../pages/DetalhePersonagem",
], (opaTest) => {
    "use strict";

    QUnit.module("DetalhePersonagem");

    opaTest("Deve navegar para os detalhes de um personagem com propósito heróico", (Given, When, Then) => {
        // Arrange
        let idPersonagem = 1;
        Given.iniciarAplicacao({ hash: `personagens/${idPersonagem}` });

        // Assert
        Then.naPaginaDetalhePersonagem.verificaUrl(idPersonagem);
        Then.naPaginaDetalhePersonagem.verificaTituloDaPagina("Detalhes do Personagem");
        Then.naPaginaDetalhePersonagem.verificaDetalhesDoPersonagem();
        Then.naPaginaDetalhePersonagem.verificaQuatidadeDaListaDeHabilidades(3);
        Then.naPaginaDetalhePersonagem.verificaClasseTextoEVilao("txtHeroi"); 
    });

    opaTest("Deve navegar de volta para a tela de listagem ao clicar no botão voltar", (Given, When, Then) => {
        // Act
        When.naPaginaDetalhePersonagem.aoClicarNoBotaoVoltar();

        // Assert
        Then.naPaginaListaPersonagem.verificaUrl();
        Then.naPaginaListaPersonagem.verificaTituloDaPagina("Lista de Personagens");
    });

    opaTest("Deve navegar para o detalhes de um personagem com propósito vilanesco", (Given, When, Then) => {
        // Arrange
        let nonoItem = 8;
        let id9 = 9;
        let quantidade5 = 5;
        let classeVilao = "txtVilao";

        // Act
        When.naPaginaListaPersonagem.aoClicarNaLista();
        When.naPaginaListaPersonagem.aoSelecionarItemDaLista(nonoItem);

        // Assert
        Then.naPaginaDetalhePersonagem.verificaUrl(id9);
        Then.naPaginaDetalhePersonagem.verificaTituloDaPagina("Detalhes do Personagem");
        Then.naPaginaDetalhePersonagem.verificaDetalhesDoPersonagem();
        Then.naPaginaDetalhePersonagem.verificaQuatidadeDaListaDeHabilidades(quantidade5);
        Then.naPaginaDetalhePersonagem.verificaClasseTextoEVilao(classeVilao); 
        Then.iTeardownMyApp();
    });
});