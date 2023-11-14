function CreateRole() {
    var res = ValidateRoleCreate();
    if (res == false) {
        return false;
    }

    var objData = {
        Name: $('#RoleCreateModal #Name').val(),
        Description: $('#RoleCreateModal #Description').val()
    }

    $.ajax({
        url: '/Role/Create',
        type: 'POST',
        data: objData,
        dataType: 'json',
        success: function (result) {
            if (result.success === true) {
                roleTable.ajax.reload();
                HideRoleCreateModal();
                toastr.success(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
            else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}

function ValidateRoleCreate() {
    var isValid = true;

    if ($('#RoleCreateModal #Name').val().trim() == "") {
        $('#RoleCreateModal #Name').css('border-color', '#dc3545');
        isValid = false;
    }

    return isValid;
}

function HideRoleCreateModal() {
    ClearTextBoxRoleCreate();
    $('#RoleCreateModal').modal('hide');
    $('#RoleCreateModal #Name').css('border-color', '#ced4da');
}

function ClearTextBoxRoleCreate() {
    $('#RoleCreateModal #Name').val('');
    $('#RoleCreateModal #Description').val('');
    $('#RoleCreateModal #Name').css('border-color', '#ced4da');
}

function EscRoleCreateModal(evt) {
    if (evt.keyCode == 27) {
        HideRoleCreateModal();
    }
}

function OnKeyUpRoleCreate() {
    $('#RoleCreateModal #Name').css('border-color', '#ced4da');
}