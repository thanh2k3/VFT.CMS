function UpdateProduct() {
    var res = ValidateProductEdit();
    if (res == false) {
        return false;
    }

    var formData = new FormData();
    formData.append('Id', $('#ProductEditModal #Id').val())
    formData.append('Name', $('#ProductEditModal #Name').val())
    formData.append('CategoryId', $('#ProductEditModal #CategoryId').find('option:selected').val())
    formData.append('Price', $('#ProductEditModal #Price').val())
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
                HideProductEditModal();
                toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

function HideProductEditModal() {
    $('#ProductEditModal').modal('hide');
}

function ValidateProductEdit() {
    var isValid = true;

    if ($('#ProductEditModal #Name').val().trim() == "") {
        $('#ProductEditModal #Name').css('border-color', '#dc3545');
        isValid = false;
    }

    if ($('#ProductEditModal #Price').val().trim() == "") {
        $('#ProductEditModal #Price').css('border-color', '#dc3545');
        isValid = false;
    }

    return isValid;
}

function OnKeyUpProductEdit() {
    $('#ProductEditModal #Name').css('border-color', '#ced4da');
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