sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/opaQunit",
    "../pages/FormularioPersonagem"
], (Opa5, opaTest) => {
    "use strict";

    QUnit.module("FormularioPersonagem - Adicionar");

    opaTest("Deve voltar para a listagem de personagens ao clicar no botão Voltar", (Given, When, Then) => {
        // Arrange
        Given.iniciarAplicacao({ hash: "personagens/adicionar" });

        // Act
        When.noFormularioPersonagem.aoClicarNoBotaoVoltar();

        // Assert
        Then.naPaginaListaPersonagem.verificaUrl();
        Then.naPaginaListaPersonagem.verificaTituloDaPagina("Lista de Personagens");
        Then.iTeardownMyApp();
    });

    opaTest("Tenta salvar um personagem sem preencher os campos do formulário", (Given, When, Then) => {
        // Arrange
        Given.iniciarAplicacao({ hash: "personagens/adicionar" });

        // Act
        When.noFormularioPersonagem.aoClicarNoBotaoSalvar();
        // Assert
        
        Then.noFormularioPersonagem.deveMostrarMessageBox("Advertência", "Por favor, corrija o(s) erro(s) no formulário antes de salvar.");
        When.noFormularioPersonagem.aoFecharMessageBox("OK");

        Then.noFormularioPersonagem.verificaTipoDosInputs("Error")
    });

    opaTest("Salvar um personagem com sucesso", (Given, When, Then) => {
        // Act
        When.noFormularioPersonagem.aoInserirNome(`Teste da Silva`);
        When.noFormularioPersonagem.aoInserirVida(100);
        When.noFormularioPersonagem.aoInserirEnergia(50);
        When.noFormularioPersonagem.aoInserirVelocidade(2);
        When.noFormularioPersonagem.aoSelecionarForca(4);
        When.noFormularioPersonagem.aoSelecionarInteligencia(4);
        When.noFormularioPersonagem.aoDefinirHabilidades([0, 2, 4]);
        When.noFormularioPersonagem.aoClicarNoBotaoSalvar()
        
        // Assert
        Then.noFormularioPersonagem.deveMostrarMessageToast("Personagem criado com êxito!");
        // Then.naPaginaDetalhePersonagem.verificaUrl(proximoId);
        Then.naPaginaDetalhePersonagem.verificaTituloDaPagina("Detalhes do Personagem");
        Then.naPaginaDetalhePersonagem.verificaDetalhesDoPersonagem()
        Then.iTeardownMyApp();
    });
});