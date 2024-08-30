sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/Home",
    "../pages/ListaPersonagem",
    "../pages/DetalhePersonagem",
], (opaTest) => {
    "use strict";

    QUnit.module("DetalhePersonagem - Excluir");

    opaTest("Deve exibir mensagem de confirmação ao clicar no botão excluir", (Given, When, Then) => {
        // Arrange
        let idPersonagem = 33;
        Given.iniciarAplicacao({ hash: `personagens/${idPersonagem}` });
        Then.naPaginaDetalhePersonagem.verificaUrl(idPersonagem);

        // Act
        When.naPaginaDetalhePersonagem.aoClicarNoBotaoExcluirPersonagem();

        // Assert
        Then.naPaginaDetalhePersonagem.verificaMensagemDeConfirmacao("Advertência", "Tem certeza que deseja excluir o registro?");
    });

    opaTest("Cancela a exclusão do personagem", (Given, When, Then) => {
        // Arrange
        let idPersonagem = 33;

        // Act
        When.naPaginaDetalhePersonagem.aoClicarNoBotaoDoMessageBox("Cancelar");

        // Assert
        Then.naPaginaDetalhePersonagem.verificaUrl(idPersonagem);
    });

    opaTest("Confirma a exclusão do personagem com êxito", (Given, When, Then) => {
        // Act
        When.naPaginaDetalhePersonagem.aoClicarNoBotaoExcluirPersonagem();
        When.naPaginaDetalhePersonagem.aoClicarNoBotaoDoMessageBox("OK");

        // Assert
        Then.naPaginaListaPersonagem.verificaUrl();
        Then.naPaginaListaPersonagem.verificaTituloDaPagina("Lista de Personagens");
        Then.naPaginaListaPersonagem.verificaQuantidadeDaListaPersonagem(32);
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




