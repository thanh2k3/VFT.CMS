// Create Product
function CreateProduct() {
    var res = ValidateProductCreate();
    if (res == false) {
        return false
    }

    var objData = new Object();
    objData.name = $('#ProductCreateModal #Name').val();
    objData.categoryId = $('#ProductCreateModal').find('#CategoryId option:selected').val();
    objData.price = $('#ProductCreateModal #Price').val();
    objData.quantity = $('#ProductCreateModal #Quantity').val();
    objData.image = $('#ProductCreateModal #Image').val();
    objData.description = $('#ProductCreateModal #Description').val();

    $.ajax({
        url: '/Product/Create',
        type: 'POST',
        data: objData,
        dataType: 'json',
        success: function (result) {
            if (result.success === true) {
                ShowProductData();
                HideProductCreateModal();
                toastr.success(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        },
        error: function () {
        }
    });
}

function HideProductCreateModal() {
    ClearTextBoxProductCreate();
    $('#ProductCreateModal').modal('hide');
    $('#ProductCreateModal #Name').css('border-color', '#ced4da');
    $('#ProductCreateModal #CategoryId').css('border-color', '#ced4da');
}

function ClearTextBoxProductCreate() {
    $('#ProductCreateModal #Name').val('');
    $('#ProductCreateModal #CategoryId').val(defaultOption);
    $('#ProductCreateModal #Price').val('');
    $('#ProductCreateModal #Quantity').val('');
    $('#ProductCreateModal #Description').val('');
    $('#ProductCreateModal #Image').val('');
}

function ValidateProductCreate() {
    var isValid = true;

    if ($('#ProductCreateModal #Name').val().trim() == "") {
        $('#ProductCreateModal #Name').css('border-color', '#dc3545');
        isValid = false;
    }

    if ($('#ProductCreateModal #CategoryId').val().trim() == defaultOption) {
        $('#ProductCreateModal #CategoryId').css('border-color', '#dc3545');
        isValid = false;
    }

    return isValid;
}

function OnKeyUpCreate() {
    $('#ProductCreateModal #Name').css('border-color', '#ced4da');
}

function ChangeSelect(obj) {
    var value = obj.value;
    if (value != "" && value != defaultOption) {
        $('#ProductCreateModal #CategoryId').css('border-color', '#ced4da');
    }
}

// Bắt sự kiện nhất nút Esc
function EscProductCreateModal(evt) {
    if (evt.keyCode == 27) {
        HideProductCreateModal();
    }
}