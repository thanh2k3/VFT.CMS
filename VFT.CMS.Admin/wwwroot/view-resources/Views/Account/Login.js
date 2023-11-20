function Login() {
    $('#formLogin').submit(function (e) {
        e.preventDefault();
    })

    var isValid = $("#formLogin").valid();
    if (!isValid)
        return

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

$('#formLogin').validate({
    errorPlacement: function (error, element) {
        return true;
    }
})

// Dùng để validation hoạt động
$(document).ready(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = document.getElementsByClassName('needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})