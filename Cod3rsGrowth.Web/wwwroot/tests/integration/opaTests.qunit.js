sap.ui.require([
	"sap/ui/core/Core",
	"coders-growth/tests/integration/NavigationJourney"
], async (Core) => {
	"use strict";

	await Core.ready();
	QUnit.start();
});