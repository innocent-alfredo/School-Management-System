$.ajaxSetup({
    cache: false,
    beforeSend: function () {
        // TODO: show your spinner
        loadPanel.show();
    },
    complete: function () {
        // TODO: hide your spinner
        loadPanel.hide();
    },
    error: function () {
        var data = {
            Status: false,
            Message: "An error occured while processing your request."
        }
        LobiAlert(data);
    }
});
var loadPanel = $(".loadpanel").dxLoadPanel({
    shadingColor: "rgba(0,0,0,0.2)",
    //position: { of: ".container-fluid" },
    visible: false,
    showIndicator: true,
    showPane: true,
    shading: true,
    closeOnOutsideClick: false
}).dxLoadPanel("instance");
var gridOptions = {
    dataSource: '',
    showColumnLines: true,
    showRowLines: true,
    rowAlternationEnabled: true,
    showBorders: true,
    loadPanel: { enabled: false },
    searchPanel: {
        visible: true,
        width: 270,
        highlightSearchText: false
    },
    paging: { enabled: true, pageIndex: 0, pageSize: 10 },
    pager: {
        showPageSizeSelector: true,
        allowedPageSizes: [10, 20, 30]
    }
}
var opt = {
    autoOpen: false,
    //width: 900,
    resizable: true,
    modal: true,
    show: { effect: 'drop', direction: "up" },
    hide: "fade",
    //position: { my: "center", at: "top+198" },
    //buttons: {
    //    "Submit": function () { $("#History").submit(); },
    //    "Cancel": function () { $(this).dialog("close") }
    //}
};
var lobiopt = {
    msg: '',
    size: 'mini',
    pauseDelayOnHover: true,
    continueDelayOnInactiveTab: false,
    delay: false,
    sound: false,
    position: '', //or 'center bottom',
}
function LobiAlert(data) {
    lobiopt.msg = data.Message;
    if (data.Status === true) {        
        lobiopt.position = 'center top';
        Lobibox.notify('success', lobiopt);
    }
    else {
        lobiopt.position = 'center bottom';
        Lobibox.notify('error', lobiopt);
    }
}
function showConfirmationDialog(data) {
    $.confirm({
        title: 'Message!',
        content: data,
        boxWidth: '35%',
        useBootstrap: false,
        autoClose: 'Ok|5000',
        buttons: {
            Ok: function () {
                //$.alert('Confirmed!');
            }
        }
    });
}