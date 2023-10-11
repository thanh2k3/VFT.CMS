function CreateCategory() {
    var result = ValidateCreate();
    if (result == false) {
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
        success: function (res) {
            if (res.success === true) {
                ShowCategoryData();
                HideCreateModal();
                toastr.success(res.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
            else {
                toastr.error(res.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}

function HideCreateModal() {
    ClearTextBox();
    $('#CategoryCreateModal').modal('hide');
    $('#CategoryCreateModal #Name').css('border-color', '#ced4da');
    $('#CategoryCreateModal #errorIcon').css('display', 'none');
}

function ClearTextBox() {
    $('#CategoryCreateModal #Name').val('');
}

function ValidateCreate() {
    var isValid = true;

    if ($('#CategoryCreateModal #Name').val().trim() == "") {
        $('#CategoryCreateModal #Name').css('border-color', '#dc3545');
        $('#CategoryCreateModal #errorIcon').css('display', 'block');
        isValid = false;
    }
    return isValid;
}

function OnKeyUpCreate() {
    $('#CategoryCreateModal #Name').css('border-color', 'lightgrey');
    $('#CategoryCreateModal #errorIcon').css('display', 'none');
}

// Bắt sự kiện nhấn nút Esc
function CloseCategoryCreateModal(evt) {
    if (evt.keyCode == 27) {
        HideCreateModal();
    }
}