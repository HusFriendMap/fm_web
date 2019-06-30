function loadAjaxContentPostData(urlContent, container, data) {
    if ($(container).length) {
        $(container).html("<img src='/Content/images/loading.gif' />");
        $.ajax({
            url: urlContent,
            data: data,
            cache: false,
            type: "POST",
            success: function (data) {
                $(container).html(data);
                return true;
            },
            error: function () {
                return false;
            }
        });
    }
}

function View(elmnt) {
    openDialogView("Chi tiết người dùng", "/ManagerUsers/ViewUser.aspx?_id=" + $(elmnt).data("id"), {});
}

$(function (even) {
    // thêm mới
    $(document).on("click", ".btn-add", function () {
        openDialogView($(this).data("title"), $(this).data("form"), { do: "UPDATE" }, "NORMAL");
    });
    $(document).find(".required").append('<span style="color:red">*</span>');
});
(function ($) {
    $.fn.smForm = function (settings) {
        var thisID = $(this).attr("id");
        $('#' + thisID + ' label.required').each(function () {
            $(this).append("(<span class='clsred'>*</span>)");
        });

        $('.input-datetime').daterangepicker({
            autoUpdateInput: false,
            singleDatePicker: true,
            locale: {
                cancelLabel: 'Clear'
            }
        });

        $('.input-datetime').on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('DD/MM/YYYY'));
        });

        $('.input-datetime').on('cancel.daterangepicker', function (ev, picker) {
            $(this).val('');
        });
    };
    $.fn.closefrmbs = function (settings) {
        $(this).closest("[role=dialog]").modal('hide');
    };
})(jQuery);

function openDialogView(stitle, urlpageLoad, data, size, funcCallBack) {
    BootstrapDialog.show({
        type: 'type-default',
        title: stitle,
        message: function (dialog) {
            var $message = dialog.getModalBody();
            if (data != undefined)
                $message.load(urlpageLoad, data, function (response, status, xhr) { });
            else
                $message.load(urlpageLoad, data);
            if (size == "NORMAL")
                dialog.setSize(BootstrapDialog.SIZE_NORMAL);
            else if (size == "SMALL")
                dialog.setSize(BootstrapDialog.SIZE_SMALL);
            else if (size == "LARGE")
                dialog.setSize(BootstrapDialog.SIZE_LARGE);
            else if (size == "FULL")
                dialog.setSize(BootstrapDialog.SIZE_FULL);
            else
                dialog.setSize(BootstrapDialog.SIZE_WIDE);
            return "";
        },
        closable: true,
        closeByBackdrop: true, // bấm ra ngoài tắt dialog
        draggable: false, //cho phép di chuyển dialog
        onshown: function (dialogRef) {
            if (funcCallBack != undefined && jQuery.isFunction(funcCallBack)) {
                funcCallBack(); //
            }
        },
    });
}