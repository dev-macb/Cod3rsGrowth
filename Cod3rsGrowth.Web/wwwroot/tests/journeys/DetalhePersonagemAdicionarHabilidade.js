sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/DetalhePersonagem",
], (opaTest) => {
    "use strict";

    QUnit.module("DetalhePersonagem - Adicionar Habilidade");

    opaTest("Deve exibir modal com formulário de adição ao clicar no butão Novo", (Given, When, Then) => {
        // Arrange
        const idAlvo = 1;
        Given.iniciarAplicacao({ hash: `personagens/${idAlvo}` });

        // Act
        When.naPaginaDetalhePersonagem.aoClicarEmNovaHabilidade();

        // Assert
        Then.naPaginaDetalhePersonagem.deveHaverUmDialogoAberto("Cadastrar Habilidade");
    });

    opaTest("Tenta salvar uma habilidade sem preencher nenhum campo", (Given, When, Then) => {
        // Act
        When.naPaginaDetalhePersonagem.aoClicarEmSalvarHabilidade();

        // Assert
        Then.naPaginaDetalhePersonagem.deveMostrarMessageBox("Advertência", "Por favor, corrija o(s) erro(s) no formulário antes de salvar.");
        When.naPaginaDetalhePersonagem.aoFecharMessageBox("OK");
    });

    opaTest("Salvar uma habilidade com sucesso sem vincular ao personagem atual", (Given, When, Then) => {
        // Arrange
        const idEsperado = 14;

        // Act
        When.naPaginaDetalhePersonagem.aoInserirNomeHabilidade("Teste");
        When.naPaginaDetalhePersonagem.aoInserirDescricaoHabilidade("Uma habilidade para teste");
        When.naPaginaDetalhePersonagem.aoClicarEmSalvarHabilidade();

        // Assert
        Then.naPaginaDetalhePersonagem.deveExibirMessageToast("Habilidade criada com êxito!");
        Then.naPaginaDetalhePersonagem.verificaQuatidadeDaListaDeHabilidades(5);
    });

    opaTest("Salvar uma habilidade com sucesso vinculando ao personagem atual", async (Given, When, Then) => {
        // Arrange
        const idEsperado = 14;

        // Act
        When.naPaginaDetalhePersonagem.aoClicarEmNovaHabilidade();
        When.naPaginaDetalhePersonagem.aoInserirNomeHabilidade("Outro Teste");
        When.naPaginaDetalhePersonagem.aoInserirDescricaoHabilidade("Uma outra habilidade para teste");
        When.naPaginaDetalhePersonagem.aoClicarEmVincularAoPersonagem();
        When.naPaginaDetalhePersonagem.aoClicarEmSalvarHabilidade();


        // Assert
        Then.naPaginaDetalhePersonagem.deveExibirMessageToast("Habilidade criada com êxito!");
        Then.naPaginaDetalhePersonagem.verificaQuatidadeDaListaDeHabilidades(6);
        Then.iTeardownMyApp();
        await HttpService.delete(Constantes.URL_Habilidade, idEsperado);
    });
});