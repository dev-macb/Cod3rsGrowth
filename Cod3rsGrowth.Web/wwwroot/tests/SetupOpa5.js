QUnit.config.autostart = false;

sap.ui.require([
    "sap/ui/core/Core",
	"sap/ui/test/Opa5",
    "coders-growth/tests/arrangements/Startup",
    "coders-growth/tests/journeys/Home",
    "coders-growth/tests/journeys/ListaHabilidade",
    "coders-growth/tests/journeys/ListaPersonagem"
], async (Core, Opa5, Startup) => {
    "use strict";

	Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "coders-growth.view",
		autoWait: true
	});

    Core.attachInit(() => QUnit.start());
});	