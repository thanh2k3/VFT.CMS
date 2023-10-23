function CreateCategory() {
    var res = ValidateCategoryCreate();
    if (res == false) {
        return false;
    }

    var objData = {
        Name: $('#CategoryCreateModal #Name').val()
    };

    $.ajax({
        url: '/Category/Create',
        type: 'POST',
        data: objData,
        dataType: 'json',
        success: function (result) {
            if (result.success === true) {
                ShowCategoryData();
                HideCategoryCreateModal();
                toastr.success(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
            else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}

function HideCategoryCreateModal() {
    ClearTextBoxCategoryCreate();
    $('#CategoryCreateModal').modal('hide');
    $('#CategoryCreateModal #Name').css('border-color', '#ced4da');
    $('#CategoryCreateModal #errorIcon').css('display', 'none');
}

function ClearTextBoxCategoryCreate() {
    $('#CategoryCreateModal #Name').val('');
}

function ValidateCategoryCreate() {
    var isValid = true;

    if ($('#CategoryCreateModal #Name').val().trim() == "") {
        $('#CategoryCreateModal #Name').css('border-color', '#dc3545');
        $('#CategoryCreateModal #errorIcon').css('display', 'block');
        isValid = false;
    }

    return isValid;
}

function OnKeyUpCategoryCreate() {
    $('#CategoryCreateModal #Name').css('border-color', 'lightgrey');
    $('#CategoryCreateModal #errorIcon').css('display', 'none');
}

// Bắt sự kiện nhấn nút Esc
function EscCategoryCreateModal(evt) {
    if (evt.keyCode == 27) {
        HideCategoryCreateModal();
    }
}