/// <reference path="jquery-1.8.0.intellisense.js" />
/// <reference path="jquery.validate.unobtrusive.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="knockout-2.1.0.debug.js" />

$(document).ready(function () {

    $(function() {
        var viewModel = {
            editImage: ko.observable(false)
        };

        ko.applyBindings(viewModel);
    });

    ///////////////////Validate FileSize//////////////////////////////////  
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
    ///////////////////Validate FileSize//////////////////////////////////

    ///////////////////Validate FileExtensions////////////////////////////
    $.validator.unobtrusive.adapters.add(
        'mimetype', ['filetype'], function (options) {
            options.rules['mimetype'] = options.params;

            $.each(options.params, function (key, val) {
                console.log("Key: " + key + " | Value: " + val);
            });

            if (options.messages) {
                options.messages['mimetype'] = options.message;
            }
        });

    $.validator.addMethod('mimetype', function (value, element, params) {
        if (element.files.length < 1) {
            // No files selected
            return true;
        }

        if (!element.files || !element.files[0].size) {
            // This browser doesn't support the HTML5 API
            return true;
        }
        var formattedFileTypes = "(";
        $.each(params.filetype, function (key, val) {
            if (val == ",") {
                val = "|";
            }
            formattedFileTypes = formattedFileTypes + val;
        });

        formattedFileTypes = formattedFileTypes + ")";
        var newString = formattedFileTypes.replace(/\s/g, "");
        var startPattern = "^.*\.";
        var endPattern = "$";
        var pattern = new RegExp(startPattern + newString + endPattern, "gi");
        var fileName = $(element).val();
        var regexResult = fileName.match(pattern);

        if (regexResult != null) {
            return true;
        }

        //console.log("Pattern: " + pattern + " | FileName: " + fileName + " | regexResult: " + regexResult);
        return false;
    }, '');





});