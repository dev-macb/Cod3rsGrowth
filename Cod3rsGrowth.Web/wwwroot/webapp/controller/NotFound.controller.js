sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/core/UIComponent"
], (Controller, History, UIComponent) => {
    "use strict";

    return Controller.extend("coders-growth.controller.NotFound", {
        onInit() {},

        onNavBack() {
            var oHistorico = History.getInstance();
            var sHashAnterior = oHistorico.getPreviousHash();

            if (sHashAnterior !== undefined) {
                window.history.go(-1);
            } else {
                var oRotiador = UIComponent.getRouterFor(this);
                oRotiador.navTo("main", {}, true);
            }
        }
    });
});