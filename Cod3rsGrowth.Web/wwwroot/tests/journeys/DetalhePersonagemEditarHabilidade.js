sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/DetalhePersonagem",
], (opaTest) => {
    "use strict";

    QUnit.module("DetalhePersonagem - Editar Habilidade");

    opaTest("Verifica se formulário vem preenchido com os dados do personagem", (Given, When, Then) => {
        // Arrange
        let idPersonagemAlvo = 2;
        let idHabilidadeAlvo = 4;
        Given.iniciarAplicacao({ hash: `personagens/${idPersonagemAlvo}` });

        // Act
        When.naPaginaDetalhePersonagem.aoClicarEmEditarHabilidade();

        // Assert
        Then.naPaginaDetalhePersonagem.deveHaverUmDialogoAberto(`Editar Habilidade (${idHabilidadeAlvo})`);
    });

    opaTest("Edita uma habilidade com sucesso", (Given, When, Then) => {
        // Act
        When.naPaginaDetalhePersonagem.aoInserirNomeHabilidade("Teste de Alteração");
        When.naPaginaDetalhePersonagem.aoInserirDescricaoHabilidade("Teste de Alteração");
        When.naPaginaDetalhePersonagem.aoClicarEmSalvarHabilidade();

        // Assert
        Then.naPaginaDetalhePersonagem.deveExibirMessageToast("Habilidade editada com êxito!");
        Then.naPaginaDetalhePersonagem.verificaQuatidadeDaListaDeHabilidades(5);
        Then.iTeardownMyApp();
    });
});