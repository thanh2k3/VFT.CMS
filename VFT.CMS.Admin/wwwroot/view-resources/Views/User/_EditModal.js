function UpdateUser() {
    var objData = {
        Id: $('#UserEditModal #Id').val(),
        Email: $('#UserEditModal #Email').val(),
        FullName: $('#UserEditModal #FullName').val(),
        Birthday: $('#UserEditModal #Birthday').val(),
    }

    $.ajax({
        url: '/User/Edit',
        data: objData,
        type: 'POST',
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