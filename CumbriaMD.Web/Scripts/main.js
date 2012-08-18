/// <reference path="jquery-1.8.0.intellisense.js" />
/// <reference path="knockout-2.1.0.debug.js" />
/// <reference path="jquery.validate.unobtrusive.js" />
/// <reference path="jquery.validate-vsdoc.js" />
/// <reference path="cumbriamd-validation.js" />

require.config({
    "packages": ["modules/knockout"],
    paths: {
        "show-uploader": "modules/knockout/show-uploader"
    }
    
});
require(["show-uploader"], function (uploader) {


});


//require.config({
//    "packages": ["modules/knockout"],
//    paths: {
//        // "jquery": "libs/jquery/jquery-1.8.0",
//        "jquery-validate": "libs/jquery/jquery.validate",
//        "jquery-validate-unobtrusive": "libs/jquery/jquery.validate.unobtrusive",
//        "knockout": "libs/knockout/knockout-2.1.0" }          
//});
//require(["domReady!", "jquery", "knockout", "jquery-validate", "jquery-validate-unobtrusive", "show-uploader"], function(domReady, $, ko) {



//});