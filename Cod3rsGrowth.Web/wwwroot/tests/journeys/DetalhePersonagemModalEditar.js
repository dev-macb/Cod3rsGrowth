    sap.ui.define([
        "sap/ui/test/opaQunit",
        "../pages/DetalhePersonagem",
    ], (opaTest) => {
        "use strict";

        QUnit.module("DetalhePersonagem - Editar Habilidade");

        opaTest("Verifica se formulário vem preenchido com os dados do personagem", (Given, When, Then) => {
            // Arrange
            let idPersonagemAlvo = 1;
            let idHabilidadeAlvo = 1;
            Given.iniciarAplicacao({ hash: `personagens/${idPersonagemAlvo}` });

            // Act
            When.naPaginaDetalhePersonagem.aoClicarEmEditarHabilidade();

            // Assert
            Then.naPaginaDetalhePersonagem.deveHaverUmDialogoAberto(`Editar Personagem (${idHabilidadeAlvo}})`);
            Then.iTeardownMyApp();
        });
    });