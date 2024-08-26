sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/opaQunit",
    "../pages/FormularioPersonagem"
], (Opa5, opaTest) => {
    "use strict";

    QUnit.module("EditarPersonagem");

    opaTest("Verifica se formulário vem preenchido com dados do personagem", (Given, When, Then) => {
        // Arrange
        let idAlvo = 1;
        Given.iniciarAplicacao({ hash: `personagens/${idAlvo}/editar` });

        // Assert   
        Then.noFormularioPersonagem.verificaUrlEditar(idAlvo);
        Then.noFormularioPersonagem.verificaTituloDaPagina("Editar Personagem");
        Then.noFormularioPersonagem.verificaSeInputsPreenchidos();
    });

    opaTest("Tenta salvar um personagem sem inserir dados inválidos", (Given, When, Then) => {
        // Act
        When.noFormularioPersonagem.aoInserirNome("T");
        When.noFormularioPersonagem.aoInserirVida(101);
        When.noFormularioPersonagem.aoInserirEnergia(51);
        When.noFormularioPersonagem.aoInserirVelocidade(2.1);
        When.noFormularioPersonagem.aoClicarNoBotaoSalvar();
        
        // Assert
        Then.noFormularioPersonagem.deveMostrarMessageBox("Advertência", "Por favor, corrija o(s) erro(s) no formulário antes de salvar.");
        When.noFormularioPersonagem.aoFecharMessageBox("OK");

        Then.noFormularioPersonagem.verificaTipoDoInput("inputNome", "Error");
        Then.noFormularioPersonagem.verificaTipoDoInput("inputVida", "Error");
        Then.noFormularioPersonagem.verificaTipoDoInput("inputEnergia", "Error");
        Then.noFormularioPersonagem.verificaTipoDoInput("inputVelocidade", "Error");
        Then.iTeardownMyApp();
    });

    opaTest("Edita um personagem com sucesso", (Given, When, Then) => {
        // Arrange
        const idAlvo = 1;
        Given.iniciarAplicacao({ hash: `personagens/${idAlvo}/editar` });

        // Act
        When.noFormularioPersonagem.aoInserirNome(`Teste de Edição`);
        When.noFormularioPersonagem.aoInserirVida(10);
        When.noFormularioPersonagem.aoInserirEnergia(5);
        When.noFormularioPersonagem.aoInserirVelocidade(0.2);
        When.noFormularioPersonagem.aoSelecionarForca(1);
        When.noFormularioPersonagem.aoSelecionarInteligencia(1);
        When.noFormularioPersonagem.aoDefinirHabilidades([1, 2, 3]);
        When.noFormularioPersonagem.aoClicarNoBotaoSalvar()
        
        // Assert
        Then.noFormularioPersonagem.deveMostrarMessageToast(`Personagem ${idAlvo} atualizado com êxito!`);
        Then.naPaginaDetalhePersonagem.verificaUrl(idAlvo);
        Then.naPaginaDetalhePersonagem.verificaTituloDaPagina("Detalhes do Personagem");
        Then.naPaginaDetalhePersonagem.verificaDetalhesDoPersonagem()
        Then.iTeardownMyApp();
    });
});