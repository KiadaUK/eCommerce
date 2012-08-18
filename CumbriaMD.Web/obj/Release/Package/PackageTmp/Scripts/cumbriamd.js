    /// <reference path="jquery-1.7.2-vsdoc.js" />
    /// <reference path="jquery-ui-1.8.11.js" />
    /// <reference path="jquery.validate.unobtrusive.js" />
    /// <reference path="jquery.validate.js" />
//$(document).ready(function () {
    //    $("#orderInList").sortable();

    //});


    //$(document).ready(function () {
    //    $('#ParentCategoryId').change(function () {
    //        var postData = $("#ParentCategoryId").val();
    //        $.getJSON("/Category/GetOrderSelectList?parentCategoryId=" + postData, function (jsonResult) {
    //            $('#orderInList option').remove();
    //            $.each(jsonResult, function (categoryId, orderInList) {
    //                $('#orderInList').append( 
    //                        $("<option value=" + orderInList + ">" + orderInList + "</option>")
    //                    );
    //            });
    //        });
    //    });
    //});

$(document).ready(function () {

//    $.validator.unobtrusive.adapters.add(
//        'filesize', ['maxsize'], function(options) {
//            options.rules['filesize'] = options.params;
//            if (options.message) {
//                options.message['filesize'] = options.message;
//            }
//        });

//        $.validator.addMethod('filesize', function (value, element, params) {
//            if (element.files.length < 1) {
//                // No files selected
//                return true;
//            }

//            if (!element.files || !element.files[0].size) {
//                // This browser doesn't support the HTML5 API
//                return true;
//            }

//            return element.files[0].size < params.maxsize;
//        }, '');


    var $dialog = $('<div></div>')
            .html('Category Name: <input type="text" name="categoryNameDialog" required="true" id="categoryNameDialog" maxlength="150" />' +
                '</br></br>' +
                '<button id="categoryNameSubmit" name="categoryNameSubmit">Accept</button>')
            .dialog({
                autoOpen: false,
                modal: true,
                title: "New Category Form",
                width: 400,
                resizable: false
            });

    // When category name modal box is submitted, close dialog and call method to set text box.
    $('button:#categoryNameSubmit').click(function () {
        var categoryName = $('#categoryNameDialog').val();
        accept_category_name_dialog(categoryName);
        $dialog.dialog('close');

    });

    // Open modal dialog box to enter category name
    $('#categoryName').focus(function () {
        render_category_name_modal_form();
    });

    //After parent category is chaqnged, the sortable list of subcategories is updated.
    var arrCategory = new Array();
    $('#ParentCategoryId').change(function () {
        var postData = $("#ParentCategoryId").val();
        $.getJSON("/Json/GetTestOrderData?parentCategoryId=" + postData, function (data) {
            render_sortable(data);
        });
    });
    /////////////////////////////////////////////////////////////////////////////////


    // Create category objects to hold sortable fields
    function objCategory(id, name, order) {
        this.Name = name;
        this.Id = id;
        this.Order = order;
    };

    function request_subcategories_on_category_name_dialog_submit() {
        var postData = $("#ParentCategoryId").val();
        $.getJSON("/Json/GetTestOrderData?parentCategoryId=1", function (data) {
            render_sortable(data);
        });
    }

    // Render the sortable categories
    function render_sortable(data) {

        $('#orderInList_test li').remove();
        $.each(data, function (key, value) {

            var category = new objCategory(value.Id, value.Name, value.OrderNumber);

            $('#orderInList_test').append('<li id="' + value.Id + '">' + value.Name + '</li>');
            arrCategory.push(category);
        });
        $('#orderInList_test').sortable();
    };

    // Send a getJSON Ajax request to create a new Category based on the name given in the dialog box, and retrieve the resulting Category (values can be changed on form submit)
    function set_category_get_default_values(categoryName) {

        $.getJSON("/Json/SetCategoryNameGetDefaultValues?categoryName=" + categoryName, function (data) {
            add_category_to_sortable(data);
        });
    };

    //Add resulting Category to sortable list.
    function add_category_to_sortable() {
        request_subcategories_on_category_name_dialog_submit();
    }

    /////////////////////////////////////////////////////////////////////////////////
    // CATEGORY NAME DIALOG BOX

    function render_category_name_modal_form() {
        $dialog.dialog('open');
        return false;
    };

    function accept_category_name_dialog(categoryName) {
        console.log(categoryName + ":    accept_category_name_dialog");
        $('#categoryName').val(categoryName);
        set_category_get_default_values(categoryName);


    };
    /////////////////////////////////////////////////////////////////////////////////

});

   


//function createSelect(jsonResult) {
//    $.each(jsonResult, function (key, value) {
//        $('orderInList').append($("<option></option>").attr("value", value.OrderInList).value(item.OrderInList));
//     });
//}



