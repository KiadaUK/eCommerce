/// <reference path="jquery-1.8.0.intellisense.js" />
/// <reference path="knockout-2.1.0.debug.js" />
/// <reference path="jquery.validate.unobtrusive.js" />
/// <reference path="jquery.validate-vsdoc.js" />
/// <reference path="cumbriamd-validation.js" />

require.config({
    paths: {
        "show-uploader": "modules/knockout/show-uploader",
        "knockout": "libs/knockout/knockout-2.1.0",
        "maximum-filesize": "modules/validation/maximum-filesize"
    }
});
require(["knockout", "show-uploader", "maximum-filesize", "domReady"], function (ko, showUploader) {

    var uploader = showUploader;
    ko.applyBindings(uploader);

});

//require.config({
//    paths: {
//        "jquery-validate": "libs/jquery/jquery.validate",
//        "jquery-validate-unobtrusive": "libs/jquery/jquery.validate.unobtrusive",
//        "knockout": "libs/knockout/knockout-2.1.0",
//        "maximum-filesize": "modules/validation/maximum-filesize"
//    }
//});
//require(["domReady!", "jquery", "knockout", "jquery-validate", "jquery-validate-unobtrusive", "maximum-filesize"], function (domReady, $, ko, maxFileSize) {



//});