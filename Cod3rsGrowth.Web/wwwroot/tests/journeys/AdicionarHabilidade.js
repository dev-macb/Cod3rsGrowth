sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/opaQunit"
], (Opa5, opaTest) => {
    "use strict";

    QUnit.module("DetalhePersonagem - Adicionar Habilidade");

    opaTest("Deve aparecer diálogo com formulário voltar para a listagem de personagens ao clicar no botão Voltar", (Given, When, Then) => {
        Given.iniciarAplicacao({ hash: "personagens/adicionar" });
        Then.iTeardownMyApp();
    });
});