sap.ui.define([
    "coders-growth/controller/BaseController",
    "sap/ui/model/resource/ResourceModel"
], (BaseController, ResourceModel) => {
    "use strict";

    return BaseController.extend("coders-growth.controller.App", {
        onInit() {
            const i18nModelo = new ResourceModel({ bundleName: "coders-growth.i18n.i18n" });
            this.getView().setModel(i18nModelo, "i18n");

            const rotiador = sap.ui.core.UIComponent.getRouterFor(this);
            rotiador.initialize();
        }
    });
});