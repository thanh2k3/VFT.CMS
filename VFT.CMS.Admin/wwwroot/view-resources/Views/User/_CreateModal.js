function CreateUser() {
    $("#formCreateUser").validate({
        errorPlacement: function (error, element) {
            return true;
        },
    });

    $('#formCreateUser').addClass('was-validated')

    var isValid = $("#formCreateUser").valid();
    if (!isValid)
        return

    var formData = new FormData();
    formData.append('Email', $('#UserCreateModal #Email').val());
    formData.append('UserName', $('#UserCreateModal #Email').val());
    formData.append('FullName', $('#UserCreateModal #FullName').val());
    formData.append('Password', $('#UserCreateModal #Password').val());
    formData.append('ConfirmPassword', $('#UserCreateModal #ConfirmPassword').val());
    formData.append('Birthday', $('#UserCreateModal #Birthday').val());
    formData.append('Image', $('#UserCreateModal #Image')[0].files[0]);

    if ($('#UserCreateModal #Password').val() != $('#UserCreateModal #ConfirmPassword').val()) {
        toastr.error(null, "Mật khẩu không trùng khớp", { timeOut: 3000, positionClass: 'toast-bottom-right' });
        return false;
    }

    $.ajax({
        url: '/User/Create',
        type: 'POST',
        data: formData,
        dataType: 'json',
        processData: false,
        contentType: false,
        success: function (result) {
            if (result.success === true) {
                dataTable.ajax.reload();
                HideUserCreateModal();
                toastr.success(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        },
        error: function () {

        }
    });
}

function HideUserCreateModal() {
    ClearTextBoxUserCreate();
    $('#UserCreateModal').modal('hide');
    $('#formCreateUser').removeClass('was-validated');
}

function ClearTextBoxUserCreate() {
    $('#UserCreateModal #Email').val('');
    $('#UserCreateModal #Password').val('');
    $('#UserCreateModal #ConfirmPassword').val('');
    $('#UserCreateModal #FullName').val('');
    $('#UserCreateModal #CreatedDate').val('');
    $('#UserCreateModal #Birthday').val('');
    $('#UserCreateModal #Image').val('');
}

function EscUserCreateModal(evt) {
    if (evt.keyCode == 27) {
        HideUserCreateModal();
    }
}