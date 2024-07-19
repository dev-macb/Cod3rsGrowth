sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
], function(Opa5, Press) {
    "use strict";

    const nomeDaView = "coders-growth.view.Home";

    Opa5.createPageObjects({
        naPaginaHome: {
            actions: {
                aoClicarEmVerListaPersonagem: function() {
                    return this.waitFor({
                        id: "btnVerListaPersonagem",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Ver Lista de Personagens' não encontrado."
                    });
                },

                aoClicarEmVerListaHabilidade: function() {
                    return this.waitFor({
                        id: "btnVerListaHabilidade",
                        viewName: nomeDaView,
                        actions: new Press(),
                        errorMessage: "Botão 'Ver Lista de Habilidades' não encontrado."
                    });
                }
            }
        }
    });
});
