sap.ui.define([
    "sap/ui/core/UIComponent",
    "sap/ui/core/routing/HashChanger"
], (UIComponent, HashChanger) => {
    "use strict";

    return UIComponent.extend("coders-growth.Component", {
        metadata: {
            interfaces: ["sap.ui.core.IAsyncContentCreation"],
            manifest: "json"
        },
        
        init() {
            UIComponent.prototype.init.apply(this, arguments);

            this.getRouter().initialize();
            this.getRouter().attachBypassed(function() {
                var trocadorDeHash = HashChanger.getInstance();
                trocadorDeHash.replaceHash("notFound");
            });
        }
    });
});