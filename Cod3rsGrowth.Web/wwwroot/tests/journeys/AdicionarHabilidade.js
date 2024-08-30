sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/opaQunit",
    "../pages/FormularioHabilidade"
], (Opa5, opaTest) => {
    "use strict";

    QUnit.module("FormularioHabilidade - Adicionar");

    opaTest("Deve voltar para a listagem de personagens ao clicar no botão Voltar", (Given, When, Then) => {
        // Arrange
        Given.iniciarAplicacao({ hash: "habilidades/adicionar" });

        // Act
        When.noFormularioHabilidade.aoClicarNoBotaoVoltar();

        // Assert
        Then.naPaginaListaHabilidade.verificaUrl();
        Then.naPaginaListaHabilidade.verificaTituloDaPagina("Lista de Habilidades");
        Then.iTeardownMyApp();
    });

    opaTest("Tenta salvar uma habilidade sem preencher os campos do formulário", (Given, When, Then) => {
        // Arrange
        Given.iniciarAplicacao({ hash: "habilidades/adicionar" });

        // Act
        When.noFormularioHabilidade.aoClicarNoBotaoSalvar();
        
        // Assert
        Then.noFormularioHabilidade.deveMostrarMessageBox("Advertência", "Por favor, corrija o(s) erro(s) no formulário antes de salvar.");
        When.noFormularioHabilidade.aoFecharMessageBox("OK");

        Then.noFormularioHabilidade.verificaTipoDosInputs("Error");
    });

    opaTest("Salvar um personagem com sucesso", (Given, When, Then) => {
        // Arrange
        const proximoId = 16;

        // Act
        When.noFormularioHabilidade.aoInserirNome("Teste abc");
        When.noFormularioHabilidade.aoInserirDescricao("Uma habilidade para teste");
        When.noFormularioHabilidade.aoClicarNoBotaoSalvar()
        
        // Assert
        Then.noFormularioHabilidade.deveMostrarMessageToast(`Habilidade ${proximoId} criada com êxito!`);
        Then.naPaginaDetalheHabilidade.verificaUrl(proximoId);
        Then.naPaginaDetalheHabilidade.verificaTituloDaPagina("Detalhes da Habilidade");
        Then.naPaginaDetalheHabilidade.verificaDetalhesDaHabilidade()
        Then.iTeardownMyApp();
    });
});