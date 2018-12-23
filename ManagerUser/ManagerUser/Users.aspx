<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ManagerUser.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" style="margin-top: 15px;">
        <!-- Modal -->
        <div class="modal fade" tabindex="-1" id="myModal" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Thông tin chi tiết</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <h2>Danh sách người dùng</h2>
        <a href="javascript:;" class="btn btn-primary text-right btn-add">Thêm</a>
        <table id="example" class="display" width="100%"></table>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).ready(function () {
                $('#example').DataTable({
                    data: <%=obj%>,
                    "language": {
                        "info": 'Hiển thị _START_ đến _END_ trên tổng số _TOTAL_ bản ghi',
                        "lengthMenu": "Hiển thị _MENU_ bản ghi",
                    },
                    "lengthMenu": [[5, 10, 20, 30, 50], [5, 10, 20, 30, 50]],
                    "dom": 'rt<"row"<"col-xs-12 col-sm-4 col-md-2 nopadding"l><"col-xs-12 col-sm-8 col-md-6 nopadding infortotal"i><"col-xs-12 col-sm-12 col-md-4 nopadding"p><"clear">>',
                    columns: [
                        {
                            "width": "20px",
                            "name": "Decade",
                            "sTitle": "Decade",
                            "mData": function (o) {
                                return '<a href="javascript:;" onclick="View(this)" data-id="' + o._id.$oid + '">' + o.Decade + '</a>';
                            }
                        },
                        {
                            "width": "20%",
                            "name": "Artist",
                            "sTitle": "Artist",
                            "mData": function (o) {
                                return o.Artist;
                            }
                        },
                        {
                            "width": "20%",
                            "name": "Title",
                            "sTitle": "Tiêu đề",
                            "mData": function (o) {
                                return o.Title;
                            }
                        },
                        {
                            "width": "20%",
                            "name": "WeeksAtOne",
                            "sTitle": "Tiêu đề",
                            "mData": function (o) {
                                return o.WeeksAtOne;
                            }
                        },
                        {
                            "sTitle": "Sửa",
                            "width": "20px",
                            "bSortable": false,
                            "mData": function (o) {
                                return '<a href="javascript:;" data-edit="' + o._id.$oid + '" class="btn-edit" title="Sửa"><i class="fas fa-pencil-alt"></i></i></a>'
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
                    ]
                });
            });
        });
        function View(elmnt) {
            loadAjaxContentPostData("/ViewUser.aspx?_id=" + $(elmnt).data("id"), ".modal-body", {});
            $("#myModal").modal();
        }
    </script>
</asp:Content>
