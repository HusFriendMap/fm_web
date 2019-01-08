<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ManagerUser.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" style="margin-top: 15px;" id="GridUsers">
        <h2>Danh sách người dùng</h2>
        <div class="text-right"><a href="javascript:;" class="btn btn-primary text-right btn-add" data-title="Thêm mới người dùng" data-form="/ManagerUsers/pFormUser">Thêm</a></div>
        <table id="example" class="display" width="100%"></table>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).ready(function () {
                var columns2 = [
                    {
                        "width": "20px",
                        "name": "Name",
                        "sTitle": "Tên người dùng",
                        "mData": function (o) {
                            return '<a href="javascript:;" onclick="View(this)" data-id="' + o._id.$oid + '">' + o.Name + '</a>';
                        }
                    },
                    {
                        "width": "20%",
                        "name": "LoginName",
                        "sTitle": "Tên đăng nhập",
                        "mData": function (o) {
                            return o.LoginName;
                        }
                    },
                    {
                        "width": "20px",
                        "name": "Gender",
                        "sTitle": "Giới tính",
                        "mData": function (o) {
                            return o.Gender == 0 ? "Nữ" : o.Gender == 1 ? "Nam" : "Khác";
                        }
                    },
                    {
                        "sTitle": "Sửa",
                        "width": "20px",
                        "bSortable": false,
                        "mData": function (o) {
                            return '<a href="javascript:;" data-form="/ManagerUsers/pFormUser" data-edit="' + o._id.$oid + '" class="btn-edit" title="Sửa"><i class="fas fa-pencil-alt"></i></i></a>'
                        }
                    },
                    {
                        "sTitle": "Xóa",
                        "width": "20px",
                        "bSortable": false,
                        "mData": function (o) {
                            return '<a href="javascript:;" data-delete="' + o._id.$oid + '" class="btn-delete" title="Xóa"><i class="fas fa-trash-alt"></i></a>'
                        }
                    }
                ];
                var table = $('#example').DataTable({
                    "processing": true,
                    "ajax": {
                        dataSrc: '',
                        type: "POST",
                        url: "/ManagerUsers/Action.ashx?do=QUERYDATA",
                    },
                    "language": {
                        "info": 'Hiển thị _START_ đến _END_ trên tổng số _TOTAL_ bản ghi',
                        "lengthMenu": "Hiển thị _MENU_ bản ghi",
                    },
                    "lengthMenu": [[5, 10, 20, 30, 50], [5, 10, 20, 30, 50]],
                    "dom": 'rt<"row"<"col-xs-12 col-sm-4 col-md-2 nopadding"l><"col-xs-12 col-sm-8 col-md-6 nopadding infortotal"i><"col-xs-12 col-sm-12 col-md-4 nopadding"p><"clear">>',
                    "columns": columns2,
                    drawCallback: function (settings) { // sk sau khi grid vẽ xong
                        
                    },
                });
                //setInterval( function () {
                //    table.ajax.reload();
                //}, 60000 );
            });
        });

        $('#example').on('draw.dt', function () {
            $(".btn-delete").click(function () {
                var that = $(this);
                BootstrapDialog.show({
                    title: "Thông báo",
                    cssClass: 'bootstrap-dialog-message',
                    message: function () {
                        var $content = '<div>' + "Bạn có chắc chắn muốn xóa người dùng này không?" + '</div>';
                        return $content;
                    },
                    closable: true,
                    draggable: false,
                    buttons: [
                        {
                            id: 'btn-1',
                            label: "Có",
                            action: function (dialogRef) {
                                dialogRef.close();
                                //loading();
                                var id = $(that).data("delete");
                                $.post("/ManagerUsers/Action.ashx?do=DELETE&_id=" + id, function (data) {
                                    if (data.Erros) {
                                        //endLoading();
                                    debugger;
                                        openDialogMsg("Đã có lỗi xảy ra", data.Message);
                                    }
                                    else {
                                    debugger;
                                        //endLoading();
                                        openDialogMsg("Thông báo", data.Message);
                                    }
                                    debugger;
                                    var $tagData = $(that).closest(".smgrid");
                                    var $idtable = $tagData.find("table.smdataTable").first().dataTable().fnDraw(false);
                                });
                            }
                        },
                        {
                            id: 'btn-2',
                            label: "Không",
                            action: function (dialogRef) {
                                dialogRef.close();
                                if (funcCall != undefined && jQuery.isFunction(funcCall)) {
                                    funcCall();
                                }
                            }
                        }]
                });
            });
            $(".btn-edit").click(function () {
                openDialogView("Sửa người dùng", $(this).data("form"), { "_id": $(this).data("edit"), do: "update" }, "NORMAL");
            });
        });
    </script>
</asp:Content>
