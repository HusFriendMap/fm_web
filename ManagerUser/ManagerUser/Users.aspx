<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ManagerUser.Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table id="example" class="display" width="100%"></table>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).ready(function () {
                $('#example').DataTable({
                    data: <%=obj%>,
                    columns: [
                        { title: "Decade" },
                        { title: "Artist" },
                        { title: "Title" },
                        { title: "WeeksAtOne" }
                    ]
                });
            });
        });
    </script>
</asp:Content>
