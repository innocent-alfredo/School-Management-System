
    $(function () {
        //$(".assignlink").button();
        //$(".assignlink1").button();
        //$(".assignlink2").button();
        $(".assignlink6").button();

        $("#assignDepartment").dialog({
            autoOpen: false,
            width: 700,            
            resizable: true,
            modal: true,
            //autoOpen: true,
            show: "clip",
            hide: "fade",
            //buttons: {
            //    "Update": function (){
            //        $("submitform").submit();
            //    },
            //        "Cancel": function () {$(this).dialog("close")}
            //}
        });
             

        $(".assignlink").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#assignDepartment');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateCarForm");
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
                //open dialog
                dialogDiv.dialog('open');
            });
            return false;
        });




        $("#assignEducation").dialog({
            autoOpen: false,
            width: 600,
            resizable: true,
            modal: true,
            show: "clip",
            hide: "fade",
            //buttons: {
            //    "Update": function (){
            //        $("submitform").submit();
            //    },
            //        "Cancel": function () {$(this).dialog("close")}
            //}
        });

        $(".assignlink1").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#assignEducation');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateCarForm1");
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
                //open dialog
                dialogDiv.dialog('open');
            });
            return false;
        });


        $("#staffrequest").dialog({
            autoOpen: false,
            width: 600,
            resizable: true,
            modal: true,
            show: "clip",
            hide: "fade",
        });

        $(".assignlink2").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#staffrequest');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateCarForm2");
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
                //open dialog
                dialogDiv.dialog('open');
            });
            return false;
        });

    });

////Cascading dropdowns -- Regions + Districts
//function myPartialView_Load() {
//    $('#Region').change(function () {
//        $.getJSON('/Staff/DistrictList/' + $('#Region').val(), function (data) {
//            var items = '<option>Select a District</option>';

//            $.each(data, function (i, district) {
//                items += "<option value='" + district.Value + "'>" + district.Text + "</option>";
//            });

//            $('#District').html(items);
//        });
//    });
//};


////DatePicker Code
$(document).ready(function () {
    $(document).on('focus', '#datefield, #datefield1', function () {
        $(this).datepicker({ changeYear: true, yearRange: 'c-65:c+10' });
    });
});
