function CreateRole() {
    $('#formCreateRole').validate({
        errorPlacement: function (error, element) {
            return true;
        },
    })

    $('#formCreateRole').addClass('was-validated')

    var isValid = $("#formCreateRole").valid();
    if (!isValid)
        return

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

function HideRoleCreateModal() {
    ClearTextBoxRoleCreate();
    $('#RoleCreateModal').modal('hide');
    $('#formCreateRole').removeClass('was-validated');
}

function ClearTextBoxRoleCreate() {
    $('#RoleCreateModal #Name').val('');
    $('#RoleCreateModal #Description').val('');
}

function EscRoleCreateModal(evt) {
    if (evt.keyCode == 27) {
        HideRoleCreateModal();
    }
}