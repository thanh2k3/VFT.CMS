function Login() {
    var res = ValidateLoginAdmin();
    if (res == false) {
        return false
    }

    var objData = {
        UserName: $('#UserName').val(),
        Password: $('#Password').val()
    }

    $.ajax({
        url: '/Account/Login',
        type: 'POST',
        data: objData,
        dataType: 'json',
        success: function (result) {
            if (result.success === true) {
                window.location.href = '/Home/Index';
            }
            else {
                Swal.fire({
                    icon: "error",
                    title: "Đăng nhập thất bại!",
                    text: "Tên tài khoản và mật khẩu không hợp lệ",
                });
                $('body').removeClass('swal2-height-auto');
            }
        }
    });
}

function ValidateLoginAdmin() {
    var isValid = true;

    if ($('#formLogin #UserName').val().trim() == "") {
        $('#formLogin #UserName').css('border-color', '#dc3545');
        isValid = false;
    }

    if ($('#formLogin #Password').val().trim() == "") {
        $('#formLogin #Password').css('border-color', '#dc3545');
        isValid = false;
    }

    return isValid;
}

$("#formLogin #UserName").keypress(function (e) {
    if (e.keyCode != 13) {
        $('#formLogin #UserName').css('border-color', '#ced4da');
    }
});

$("#formLogin #Password").keypress(function (e) {
    if (e.keyCode != 13) {
        $('#formLogin #Password').css('border-color', '#ced4da');
    }
});

$("#formLogin #UserName,#Password").keypress(function (e) {
    if (e.keyCode == 13) {
        e.preventDefault();
        Login();
    }
});