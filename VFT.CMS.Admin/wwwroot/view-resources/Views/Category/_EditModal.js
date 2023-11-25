// Update
function UpdateCategory() {
    $('#formEditCategory').validate({
        errorPlacement: function (error, element) {
            return true;
        },
    })

    $('#formEditCategory').addClass('was-validated')

    var isValid = $("#formEditCategory").valid();
    if (!isValid)
        return

    var objData = {
        Id: $('#CategoryEditModal #Id').val(),
        Name: $('#CategoryEditModal #Name').val()
    }

    $.ajax({
        url: '/Category/Edit',
        data: objData,
        type: 'POST',
        success: function (result) {
            if (result.success === true) {
                $('#CategoryEditModal').modal('hide');
                ShowCategoryData();
                toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}