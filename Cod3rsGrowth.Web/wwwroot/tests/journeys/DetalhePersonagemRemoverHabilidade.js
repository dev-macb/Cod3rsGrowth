sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/DetalhePersonagem",
], (opaTest) => {
    "use strict";

    QUnit.module("DetalhePersonagem - Remover Habilidade");

    opaTest("Verifica se formulário vem preenchido com os dados do personagem", (Given, When, Then) => {
        // Arrange
        const idPersonagemAlvo = 1;
        const idHabilidadeAlvo = 1;
        Given.iniciarAplicacao({ hash: `personagens/${idPersonagemAlvo}` });

        // Act
        Then.naPaginaDetalhePersonagem.verificaQuatidadeDaListaDeHabilidades(6);
        When.naPaginaDetalhePersonagem.aoClicarEmExcluirHabilidade();

        // Assert
        Then.noFormularioPersonagem.deveMostrarMessageBox("Advertência", "Tem certeza que deseja remover essa habilidade do personagem?");
        When.noFormularioPersonagem.aoFecharMessageBox("OK");

        Then.naPaginaDetalhePersonagem.deveExibirMessageToast("Habilidade excluída com êxito!");
        Then.naPaginaDetalhePersonagem.verificaQuatidadeDaListaDeHabilidades(5);
        Then.iTeardownMyApp();
    });
});