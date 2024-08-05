sap.ui.define([
    "coders-growth/controller/BaseController",
], (BaseController) => {
    "use strict";

    return BaseController.extend("coders-growth.controller.AdicionarPersonagem", {
        onInit: function () {
            console.log("ADICIONAR PERSONAGEM")
        },
    });
});