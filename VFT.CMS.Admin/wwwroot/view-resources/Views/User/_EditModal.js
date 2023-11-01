function UpdateUser() {
    var formData = new FormData();
    formData.append('Id', $('#UserEditModal #Id').val());
    formData.append('Email', $('#UserEditModal #Email').val());
    formData.append('FullName', $('#UserEditModal #FullName').val());
    formData.append('Birthday', $('#UserEditModal #Birthday').val());
    formData.append('Image', $('#UserEditModal #Image')[0].files[0]);

    $.ajax({
        url: '/User/Edit',
        data: formData,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (result) {
            if (result.success === true) {
                HideUserEditModal();
                ShowUserData();
                toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

function HideUserEditModal() {
    $('#UserEditModal').modal('hide');
}

function LoadUserEditImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#UserEditModal #targetImage').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}