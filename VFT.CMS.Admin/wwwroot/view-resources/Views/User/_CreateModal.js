function CreateUser() {
    var res = ValidateUserCreate();
    if (res == false) {
        return false
    }

    var objData = {
        Email: $('#UserCreateModal #Email').val(),
        UserName: $('#UserCreateModal #Email').val(),
        FullName: $('#UserCreateModal #FullName').val(),
        Password: $('#UserCreateModal #Password').val(),
        ConfirmPassword: $('#UserCreateModal #ConfirmPassword').val(),
        Birthday: $('#UserCreateModal #Birthday').val()
    };

    if (objData.Password != objData.ConfirmPassword) {
        toastr.error(null, "Mật khẩu không trùng khớp", { timeOut: 3000, positionClass: 'toast-bottom-right' });
        return false;
    }

    $.ajax({
        url: '/User/Create',
        type: 'POST',
        data: objData,
        dataType: 'json',
        success: function (result) {
            if (result.success === true) {
                ShowUserData();
                HideUserCreateModal();
                toastr.success(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        },
        error: function () {

        }
    })
}

function ValidateUserCreate() {
    var isValid = true;

    if ($('#UserCreateModal #Email').val().trim() == "") {
        $('#UserCreateModal #Email').css('border-color', '#dc3545');
        isValid = false;
    }

    if ($('#UserCreateModal #Password').val().trim() == "") {
        $('#UserCreateModal #Password').css('border-color', '#dc3545');
        isValid = false;
    }

    if ($('#UserCreateModal #ConfirmPassword').val().trim() == "") {
        $('#UserCreateModal #ConfirmPassword').css('border-color', '#dc3545');
        isValid = false;
    }

    return isValid;
}

function HideUserCreateModal() {
    ClearTextBoxUserCreate();
    $('#UserCreateModal').modal('hide');
    $('#UserCreateModal #Email').css('border-color', '#ced4da');
    $('#UserCreateModal #Password').css('border-color', '#ced4da');
    $('#UserCreateModal #ConfirmPassword').css('border-color', '#ced4da');
    $('#UserCreateModal #CreatedDate').css('border-color', '#ced4da');
}

function ClearTextBoxUserCreate() {
    $('#UserCreateModal #Email').val('');
    $('#UserCreateModal #Password').val('');
    $('#UserCreateModal #ConfirmPassword').val('');
    $('#UserCreateModal #FullName').val('');
    $('#UserCreateModal #CreatedDate').val('');
    $('#UserCreateModal #Birthday').val('');
}

function EscUserCreateModal(evt) {
    if (evt.keyCode == 27) {
        HideUserCreateModal();
    }
}

function OnKeyUpUserCreateEmail() {
    $('#UserCreateModal #Email').css('border-color', '#ced4da');
}

function OnKeyUpUserCreatePassword() {
    $('#UserCreateModal #Password').css('border-color', '#ced4da');
}

function OnKeyUpUserCreateConfirmPassword() {
    $('#UserCreateModal #ConfirmPassword').css('border-color', '#ced4da');
}

function OnKeyUpUserCreateCreatedDate(evt) {
    if (evt.keyCode >= 48 && evt.keyCode <= 57) {
        $('#UserCreateModal #CreatedDate').css('border-color', '#ced4da');
    }
}