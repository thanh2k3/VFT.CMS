function CreateProduct() {
    var res = ValidateProductCreate();
    if (res == false) {
        return false
    }

    var formData = new FormData();
    formData.append('Name', $('#ProductCreateModal #Name').val());
    formData.append('CategoryId', $('#ProductCreateModal #CategoryId').find('option:selected').val());
    formData.append('Price', $('#ProductCreateModal #Price').val());
    formData.append('Description', $('#ProductCreateModal #Description').val());
    formData.append('Image', $('#ProductCreateModal #Image')[0].files[0]);

    $.ajax({
        url: '/Product/Create',
        type: 'POST',
        data: formData,
        dataType: 'json',
        processData: false,
        contentType: false,
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
    $('#ProductCreateModal #Price').css('border-color', '#ced4da');
    $('#ProductCreateModal #targetImage').attr('src', "/image/product/noimage.png");
}

function ClearTextBoxProductCreate() {
    $('#ProductCreateModal #Name').val('');
    $('#ProductCreateModal #CategoryId').val(defaultOption);
    $('#ProductCreateModal #Price').val('');
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

    if ($('#ProductCreateModal #Price').val().trim() == "") {
        $('#ProductCreateModal #Price').css('border-color', '#dc3545');
        isValid = false;
    }

    return isValid;
}

function OnKeyUpProductCreateName() {
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

function LoadProductCreateImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#ProductCreateModal #targetImage').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}