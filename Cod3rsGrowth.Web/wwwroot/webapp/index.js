sap.ui.define([
	"sap/ui/core/ComponentContainer"
], (ComponentContainer) => {
	"use strict";

	new ComponentContainer({
		name: "coders-growth",
		settings : { id : "coders-growth" },
		async: true
	}).placeAt("content");
});