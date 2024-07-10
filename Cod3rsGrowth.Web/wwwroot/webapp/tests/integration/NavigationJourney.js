sap.ui.define([
    "sap/ui/test/opaQunit",
    "./pages/App"
], (opaTest) => {
    "use strict";

    QUnit.module("Navigation");

    opaTest("Deve ver o texto esperado", (Given, When, Then) => {
        Given.iStartMyUIComponent({
            componentConfig: { name: "coders-growth" }
        });

        Then.onTheAppPage.iShouldSeeTheExpectedText();
        Then.iTeardownMyApp();
    });
});