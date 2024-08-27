sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem",
    "../pages/DetalhePersonagem",
], (opaTest) => {
    "use strict";

    QUnit.module("Excluir Personagem");

    opaTest("Deve exibir mensagem de confirmação ao clicar no botão excluir", (Given, When, Then) => {
        // Arrange
        let idPersonagem = 33;
        Given.iniciarAplicacao({ hash: `personagens/${idPersonagem}` });

        // Act
        When.naPaginaDetalhePersonagem.aoClicarNoBotaoExcluirPersonagem();

        // Assert
        Then.naPaginaDetalhePersonagem.verificaMensagemDeConfirmacao("Advertência", "Tem certeza que deseja excluir o registro?");
    });

    opaTest("Confirma a exclusão do personagem com êxito", (Given, When, Then) => {
        // Act
        When.naPaginaDetalhePersonagem.aoClicarNoBotaoDoMessageBox("OK");

        // Assert
        Then.naPaginaListaPersonagem.verificaUrl();
        Then.naPaginaListaPersonagem.verificaTituloDaPagina("Lista de Personagens");
        Then.iTeardownMyApp();
    });

    opaTest("Deve navegar para Not Found ao buscar personagem excluído", (Given, When, Then) => {
        // Arrange
        let idPersonagemExcluido = 33;
        Given.iniciarAplicacao({ hash: `personagens/${idPersonagemExcluido}` });

        // Assert
        Then.naPaginaNotFound.verificaUrl();
        Then.iTeardownMyApp();
    });
});




