sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/Properties"
], (Opa5, Properties) => {
    "use strict";

    const sNameView = "coders-growth.view.App";

    Opa5.createPageObjects({
        onTheAppPage: {
            actions: {},
            assertions: {
                iShouldSeeTheExpectedText() {
                    return this.waitFor({
                        id: "txtOlaMundo",
                        viewName: sNameView,
                        matchers: new Properties({ text: "Olá Mundo!!!" }),
                        success() {
                            Opa5.assert.ok(true, "O texto é o valor esperado");
                        },
                        errorMessage: "O texto não é o valor esperado"
                    });
                }
            }
        }
    });
});
