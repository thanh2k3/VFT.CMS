// Update Product
function UpdateProduct() {
    var res = ValidateProductEdit();
    if (res == false) {
        return false;
    }

    var objData = {
        Id: $('#ProductEditModal #Id').val(),
        Name: $('#ProductEditModal #Name').val(),
        CategoryId: $('#ProductEditModal #CategoryId').find('option:selected').val(),
        Price: $('#ProductEditModal #Price').val(),
        Image: $('#ProductEditModal #Image').val(),
        Description: $('#ProductEditModal #Description').val()
    }

    $.ajax({
        url: '/Product/Edit',
        data: objData,
        type: 'POST',
        success: function (result) {
            if (result.success === true) {
                HideProductEditModal();
                ShowProductData();
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