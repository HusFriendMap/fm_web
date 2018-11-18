<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ManagerUser.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table id="example" class="display" width="100%"></table>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).ready(function () {
                $('#example').DataTable({
                    data: <%=obj%>,
                    columns: [
                        {
                            "width": "20%",
                            "name": "Decade",
                            "sTitle": "Decade",
                
                            "mData": function (o) {
                                return o.Decade;
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
                        }
                    ]
                });
            });
        });
    </script>
</asp:Content>
