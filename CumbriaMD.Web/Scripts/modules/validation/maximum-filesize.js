/// <reference path="knockout-2.1.0.debug.js" />

require.config({
    paths: {
        "jquery-validate": "libs/jquery/jquery.validate",
        "jquery-validate-unobtrusive": "libs/jquery/jquery.validate.unobtrusive"
    }
});

define(["jquery", "jquery-validate", "jquery-validate-unobtrusive", "domReady"], function ($) {

    $.validator.unobtrusive.adapters.add(
        'filesize', ['maxsize'], function (options) {
            options.rules['filesize'] = options.params;

            if (options.messages) {
                options.messages['filesize'] = options.message;
            }
        });

    $.validator.addMethod('filesize', function (value, element, params) {
        if (element.files.length < 1) {
            // No files selected
            return true;
        }

        if (!element.files || !element.files[0].size) {
            // This browser doesn't support the HTML5 API
            return true;
        }

        return element.files[0].size < params.maxsize;
    }, '');

});




//$.validator.unobtrusive.adapters.add(
//    'filesize', ['maxsize'], function (options) {
//        options.rules['filesize'] = options.params;

//        if (options.messages) {
//            options.messages['filesize'] = options.message;
//        }
//    });

//$.validator.addMethod('filesize', function (value, element, params) {
//    if (element.files.length < 1) {
//        // No files selected
//        return true;
//    }

//    if (!element.files || !element.files[0].size) {
//        // This browser doesn't support the HTML5 API
//        return true;
//    }

//    return element.files[0].size < params.maxsize;
//}, '');