
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
            }
        });
    }
}

$(function (even) {
    // thêm mới
    $(document).on("click", ".btn-add", function () {
        AddFormDialog(urlform, widthform, $title, $(this).data());
    });
});