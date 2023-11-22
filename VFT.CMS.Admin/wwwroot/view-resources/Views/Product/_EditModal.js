function UpdateProduct() {
    $('#formEditProduct').validate({
        errorPlacement: function (error, element) {
            return true;
        },
    })

    $('#formEditProduct').addClass('was-validated')

    var isValid = $("#formEditProduct").valid();
    if (!isValid)
        return

    var formData = new FormData();
    formData.append('Id', $('#ProductEditModal #Id').val())
    formData.append('Name', $('#ProductEditModal #Name').val())
    formData.append('CategoryId', $('#ProductEditModal #CategoryId').find('option:selected').val())
    formData.append('Price', ($('#ProductEditModal #Price').val()).replaceAll('.', ''));
    formData.append('Description', $('#ProductEditModal #Description').val())
    formData.append('Image', $('#ProductEditModal #Image')[0].files[0])

    $.ajax({
        url: '/Product/Edit',
        data: formData,
        type: 'POST',
        processData: false,
        contentType: false,
        success: function (result) {
            if (result.success === true) {
                dataTable.ajax.reload();
                $('#ProductEditModal').modal('hide');
                toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

function LoadProductEditImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ProductEditModal #targetImage').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}