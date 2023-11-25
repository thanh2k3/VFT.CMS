// Update
function UpdateRole() {
    $('#formEditRole').validate({
        errorPlacement: function (error, element) {
            return true;
        },
    })

    $('#formEditRole').addClass('was-validated')

    var isValid = $('#formEditRole').valid();
    if (!isValid)
        return

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
                roleTable.ajax.reload();
                $('#RoleEditModal').modal('hide');
                toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}