// Update
function UpdateRole() {
    var res = ValidateRoleEdit();
    if (res == false) {
        return false;
    }

    var objData = {
        id: $('#RoleEditModal #Id').val(),
        Name: $('#RoleEditModal #Name').val(),
        Description: $('#RoleEditModal #Description').val()
    };

    $.ajax({
        url: '/Role/Edit',
        data: objData,
        type: 'POST',
        success: function (result) {
            if (result.success === true) {
                HideRoleEditModal();
                ShowRoleData();
                toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}

function ValidateRoleEdit() {
    var isValid = true;

    if ($('#RoleEditModal #Name').val().trim() == "") {
        $('#RoleEditModal #Name').css('border-color', '#dc3545');
        isValid = false;
    }

    return isValid;
}

function HideRoleEditModal() {
    $('#RoleEditModal').modal('hide');
    $('#RoleEditModal #Name').css('border-color', '#ced4da');
}

function OnKeyUpRoleEdit() {
    $('#RoleEditModal #Name').css('border-color', 'lightgrey');
}