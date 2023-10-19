// Edit Product
function UpdateProduct() {
    var res = ValidateProductEdit();
    if (res == false) {
        return false;
    }

    var objData = new Object();
    objData.id = $('#ProductEditModal #Id').val();
    objData.name = $('#ProductEditModal #Name').val();
    objData.categoryId = $('#ProductEditModal').find('#CategoryId option:selected').val();
    objData.price = $('#ProductEditModal #Price').val();
    objData.quantity = $('#ProductEditModal #Quantity').val();
    objData.image = $('#ProductEditModal #Image').val();
    objData.description = $('#ProductEditModal #Description').val();

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

    return isValid;
}

function OnKeyUpProductEdit() {
    $('#ProductEditModal #Name').css('border-color', '#ced4da');
}