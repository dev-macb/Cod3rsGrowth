sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/resource/ResourceModel"
], (Controller, ResourceModel) => {
    "use strict";

    return Controller.extend("coders-growth.controller.App", {
        onInit() {
            const i18nModelo = new ResourceModel({ bundleName: "coders-growth.i18n.i18n" });
            this.getView().setModel(i18nModelo, "i18n");

            const oRotiador = sap.ui.core.UIComponent.getRouterFor(this);
            oRotiador.initialize();
        }
    });
});