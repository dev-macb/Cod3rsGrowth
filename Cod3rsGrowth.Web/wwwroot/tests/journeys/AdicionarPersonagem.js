sap.ui.define([
    "sap/ui/test/opaQunit",
    "../pages/AdicionarPersonagem"
], (opaTest) => {
    "use strict";

    QUnit.module("AdicionarPersonagem");

    opaTest("Deveria adicionar um novo personagem com sucesso", (Given, When, Then) => {
        // Arrange
        Given.iStartMyApp({ hash: "/#/personagens/adicionar" });

        // Act
        When.noFormularioPersonagem.aoInserirNome("Teste da Silva");
        When.noFormularioPersonagem.aoInserirVida(100);
        When.noFormularioPersonagem.aoInserirEnergia(50);
        When.noFormularioPersonagem.aoInserirVelocidade(1);
        When.noFormularioPersonagem.aoSelecionarForca(4);
        When.noFormularioPersonagem.aoSelecionarInteligencia(4);
        When.noFormularioPersonagem.aoDefinirEVilao(true);
        When.noFormularioPersonagem.aoDefinirHabilidades([1, 2, 3]);
        When.noFormularioPersonagem.aoClicarNoBotaoSalvar();
        
        // Assert
        Then.noFormularioPersonagem.deveMostrarMessageToastComMensagem("Personagem adicionado com sucesso.");
        Then.iTeardownMyApp();
    });
});