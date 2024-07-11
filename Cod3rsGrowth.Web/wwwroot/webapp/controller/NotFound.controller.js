sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/core/UIComponent"
], (Controller, History, UIComponent) => {
    "use strict";

    return Controller.extend("coders-growth.controller.NotFound", {
        onInit() {},

        voltarNavegacao() {
            var historico = History.getInstance();
            var hashAnterior = historico.getPreviousHash();            

            if (hashAnterior === undefined || hashAnterior === "notFound") {
                var rotiador = UIComponent.getRouterFor(this);
                rotiador.navTo("home", {}, true);
            } else {
                window.history.go(-1);
            }
        }
    });
});