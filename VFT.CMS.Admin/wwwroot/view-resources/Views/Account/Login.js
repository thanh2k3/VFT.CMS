function Login() {
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
                alert('Đăng nhập thất bại');
                window.location.href = '/Account/Login';
            }
        }
    });
}