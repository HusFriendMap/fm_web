<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="ManagerUser.ViewUser" %>

<div id="form_User">
    <form class="box_view form-horizontal">
        <div class="form-group">
            <label for="Name" class="col-xs-2 control-label">Tên người dùng</label>
            <div class="col-xs-4">
                <p class="form-control-static"><%:oUser.Name %></p>
            </div>
            <label for="LoginName" class="col-xs-2 control-label">Tên đăng nhập</label>
            <div class="col-xs-4">
                <p class="form-control-static"><%:oUser.LoginName %></p>
            </div>
        </div>
        <div class="form-group">
            <label for="DateOfBirth" class="col-xs-2 control-label">Ngày sinh</label>
            <div class="col-xs-4">
                <p class="form-control-static"></p>
            </div>
            <label for="Gender" class="col-xs-2 control-label">Giới tính</label>
            <div class="col-xs-4">
                <p class="form-control-static"><%:oUser.Gender == 1 ? "Nam" : "Nữ" %></p>
            </div>
        </div>
        <div class="form-group" id="LastLogin">
            <label for="LastLogin" class="col-xs-2 control-label">đăng nhập lần cuối</label>
            <div class="col-xs-4">
            </div>
            <label for="LastLocal" class="col-xs-2 control-label">vị trí cuối cùng</label>
            <div class="col-xs-4">
                <p class="form-control-static"><%:oUser.LastLocal %></p>
            </div>
        </div>
        <div class="form-group text-right">
            <div class="col-xs-12">
                <button class="btn btn-default btn-huy" type="button">Đóng</button>
            </div>
        </div>
    </form>
</div>

<script type="text/javascript">
    $(document).ready(function () {
        $(".btn-huy").click(function () {
            $(this).closefrmbs();
        });
    });
</script>