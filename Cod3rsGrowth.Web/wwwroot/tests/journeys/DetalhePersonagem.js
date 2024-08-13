sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem",
    "../pages/DetalhePersonagem",
], (opaTest) => {
    "use strict";

    QUnit.module("DetalhePersonagem");

    opaTest("Deve navegar para o detalhes de um herói", (Given, When, Then) => {
        // Arrange
        let primeiroItem = 0;
        let id1 = 1;
        let quantidade5 = 5;
        let classeHeroi = "txtHeroi";
        Given.iniciarAplicacao();
        When.naPaginaHome.aoClicarEmVerListaPersonagem();

        // Act
        When.naPaginaListaPersonagem.aoClicarNaLista();
        When.naPaginaListaPersonagem.aoSelecionarItemDaLista(primeiroItem);

        // Assert
        Then.naPaginaDetalhePersonagem.verificaUrl(id1);
        Then.naPaginaDetalhePersonagem.verificaTituloListaPersonagem();
        Then.naPaginaDetalhePersonagem.verificaDetalhesDoPersonagem();
        Then.naPaginaDetalhePersonagem.verificaQuatidadeDaListaDeHabilidades(quantidade5);
        Then.naPaginaDetalhePersonagem.verificaClasseTextoEVilao(classeHeroi); 
    });

    opaTest("Deve navegar de volta para a tela de listagem", (Given, When, Then) => {
        // Act
        When.naPaginaDetalhePersonagem.aoClicarNoBotaoVoltar();

        // Assert
        Then.naPaginaListaPersonagem.verificaUrl();
        Then.naPaginaListaPersonagem.verificaTituloListaPersonagem();
    });

    opaTest("Deve navegar para o detalhes de um vilão", (Given, When, Then) => {
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
        Then.naPaginaDetalhePersonagem.verificaTituloListaPersonagem();
        Then.naPaginaDetalhePersonagem.verificaDetalhesDoPersonagem();
        Then.naPaginaDetalhePersonagem.verificaQuatidadeDaListaDeHabilidades(quantidade5);
        Then.naPaginaDetalhePersonagem.verificaClasseTextoEVilao(classeVilao); 

        Then.iTeardownMyApp();
    });
});