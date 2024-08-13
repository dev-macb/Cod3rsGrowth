sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/AdicionarPersonagem"
], (opaTest) => {
    "use strict";

    // TODO: Alterar nome para Formulario Personagem
    QUnit.module("AdicionarPersonagem");

    opaTest("Deve voltar para a listagem de personagens ao clicar no botão Voltar", (Given, When, Then) => {
        // Arrange
        Given.iniciarAplicacao({ hash: "personagens/adicionar" });

        // Act
        When.noFormularioPersonagem.aoClicarNoBotaoVoltar();

        // Assert
        Then.naPaginaListaPersonagem.verificaUrl();
        Then.iTeardownMyApp();
    });

    opaTest("Tenta salvar um personagem sem inserir dados", (Given, When, Then) => {
        // Arrange
        Given.iniciarAplicacao({ hash: "personagens/adicionar" });

        // Act
        When.noFormularioPersonagem.aoClicarNoBotaoSalvar();

        // Assert
        Then.noFormularioPersonagem.deveMostrarMessageBox("Advertência", "Por favor, corrija o(s) erro(s) no formulário antes de salvar.");
        When.noFormularioPersonagem.aoFecharMessageBox("OK");
    });

    opaTest("Tenta salvar um personagem com sucesso", (Given, When, Then) => {
        // Arrange
        // TODO: Implementar um id dinamico para todos os testes
        const idEsperado = 72;

        // Act
        When.noFormularioPersonagem.aoInserirNome(`Teste ${idEsperado}`);
        When.noFormularioPersonagem.aoInserirVida(100);
        When.noFormularioPersonagem.aoInserirEnergia(50);
        When.noFormularioPersonagem.aoInserirVelocidade(2);
        When.noFormularioPersonagem.aoSelecionarForca(4);
        When.noFormularioPersonagem.aoSelecionarInteligencia(4);
        When.noFormularioPersonagem.aoDefinirHabilidades([0, 2, 4]);
        When.noFormularioPersonagem.aoClicarNoBotaoSalvar();
        
        // Assert
        // TODO: Corrigir método deveMostrarMessageToast
        // Then.noFormularioPersonagem.deveMostrarMessageToast();
        Then.naPaginaDetalhePersonagem.verificaUrl(idEsperado);
        Then.iTeardownMyApp();
    });
});