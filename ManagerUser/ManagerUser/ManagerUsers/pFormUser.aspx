<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pFormUser.aspx.cs" Inherits="ManagerUser.pFormUser" %>

<form id="frm-User" class="form-horizontal container-fluid form-padding modal-body">
    <input type="hidden" name="_id" id="_id" value="<%:User._id %>" />
    <input type="hidden" name="do" id="do" value="<%:action %>" />
    <div class="form-horizontal frm-dialog">
        <div class="form-group">
            <label for="Name" class="col-xs-3 required">Tên người dùng </label>
            <div class="col-xs-9">
                <input type="text" name="Name" id="Name" class="form-control" value="<%:User.Name %>">
            </div>
        </div>
        <div class="form-group">
            <label for="LoginName" class="col-xs-3 required">Tên đăng nhập </label>
            <div class="col-xs-9">
                <input type="text" name="LoginName" id="LoginName" class="form-control" value="<%:User.LoginName %>">
            </div>
        </div>
        <div class="form-group">
            <label for="PassWord" class="col-xs-3 required">PassWord </label>
            <div class="col-xs-9">
                <input type="password" name="PassWord" id="PassWord" class="form-control" value="<%:User.PassWord %>">
            </div>
        </div>
        <div class="form-group">
            <label for="PassWord" class="col-xs-3 required">Nhập lại PassWord </label>
            <div class="col-xs-9">
                <input type="password" id="re_PassWord" class="form-control">
            </div>
        </div>
        <div class="form-group">
            <label for="DateOfBirth" class="col-xs-3">Ngày sinh</label>
            <div class="col-xs-9">
                <input type="text" name="DateOfBirth" id="DateOfBirth" class="form-control" value="">
            </div>
        </div>
        <div class="form-group">
            <label for="Gender" class="col-xs-3">Giới tính</label>
            <div class="col-xs-9">
                <select name="Gender" id="Gender" class="form-control">
                    <option value="">Chọn</option>
                    <option value="1" <%:User.Gender == 1 ? "selected" : "" %>>Nam</option>
                    <option value="2" <%:User.Gender == 2 ? "selected" : "" %>>Nữ</option>
                    <option value="3" <%:User.Gender == 3 ? "selected" : "" %>>Khác</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label for="LastLogin" class="col-xs-3">đăng nhập lần cuối</label>
            <div class="col-xs-9">
                <input type="text" name="LastLogin" id="LastLogin" class="form-control" value="">
            </div>
        </div>
        <div class="form-group">
            <label for="LastLocal" class="col-xs-3">vị trí cuối cùng </label>
            <div class="col-xs-9">
                <input type="text" name="LastLocal" id="LastLocal" class="form-control" value="<%:User.LastLocal %>">
            </div>
        </div>
        <div class="form-group text-right">
            <div class="col-xs-12">
                <button class="btn btn-primary" type="submit">Cập nhật</button>
                <button class="btn btn-default btn-huy" type="button">Hủy</button>
            </div>
        </div>
    </div>
</form>

<script type="text/javascript">
    $(document).ready(function () {
        $(".btn-huy").click(function () {
            $(this).closefrmbs();
        });
        $("#frm-User").smForm();
        $("#frm-User").validate({
            rules: {
                Name: { required: true, minlength: 3, maxlength: 255 },
                LoginName: { required: true, minlength: 3, maxlength: 255 },
                PassWord: { required: true, minlength: 6, maxlength: 255 },
                re_Password: { required: true, minlength: 6, maxlength: 255, equalTo: "#PassWord" },
                Email: { email: true },
                SoDienThoai: { Phone: true }
            },
            messages: {
                Name: {
                    required: "Chưa nhập tên đầy đủ!",
                    minlength: "Nhập ít nhất 3 ký tự",
                    maxlength: "Nhập tối đa 255 ký tự"
                },
                LoginName: {
                    required: "Chưa nhập tên đăng nhập!",
                },
                PassWord: {
                    required: "Chưa nhập password!",
                    minlength: "Nhập ít nhất 6 ký tự",
                    maxlength: "Nhập tối đa 255 ký tự"
                },
                re_Password: {
                    required: "Chưa nhập lại mật khẩu",
                    equalTo: "Mật khẩu không đúng"
                },
                Email: { email: "Vui lòng nhập đúng định dạng email" },
                SoDienThoai: { Phone: "Vui lòng nhập đúng định dạng số điện thoại" }
            },
            submitHandler: function () { //onSubmit
                $.post("/ManagerUsers/Action.ashx", $("#frm-User").serialize(), function (data) {
                    if (data.Erros) {
                        createMessage("Đã có lỗi xảy ra", data.Message); // Tạo thông báo lỗi
                    }
                    else {
                        debugger;
                        $(this).closefrmbs();
                        $('#example').dataTable().fnDraw();
                    }
                });
                return false;
            }
        });

        jQuery.validator.addMethod("alphanumeric", function (value, element) {
            return this.optional(element) || /^\w+$/i.test(value);
        }, "Không sử dụng các ký tự đặc biệt");

        jQuery.validator.addMethod("Phone", function (phone_number, element) {
            phone_number = phone_number.replace(/\s+/g, "");
            return this.optional(element) || phone_number.length > 9 &&
                phone_number.match(/^(\+84|0)[1-9]\d{8,9}$/);
        }, "Nhập đúng định dạng số điện thoại");
    });
</script>
