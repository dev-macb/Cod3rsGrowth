sap.ui.define([
    "sap/ui/core/UIComponent"
], (UIComponent) => {
    "use strict";
    
    return UIComponent.extend("coders-growth.Component", {
        metadata : {
            "interfaces": ["sap.ui.core.IAsyncContentCreation"],
            "rootView": { "id": "app", "type": "XML", "viewName": "coders-growth.view.App" }
        }
    });
});