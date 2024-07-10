sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/resource/ResourceModel"
], (Controller, ResourceModel) => {
    "use strict";

    return Controller.extend("coders-growth.controller.App", {
        onInit() {
            const i18nModel = new ResourceModel({ bundleName: "coders-growth.i18n.i18n" });
            this.getView().setModel(i18nModel, "i18n");
        }
    });
});