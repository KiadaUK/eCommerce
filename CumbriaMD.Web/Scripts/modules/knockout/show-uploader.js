/// <reference path="knockout-2.1.0.debug.js" />

require.config({
    paths: {
        "knockout": "libs/knockout/knockout-2.1.0"
    }
});
define(["domReady!", "knockout", "domReady"], function (domReady, ko) {

        return viewModel = {
            editImage: ko.observable(false)
        };     
});

