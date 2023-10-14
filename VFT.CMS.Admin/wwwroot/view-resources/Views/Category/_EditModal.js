// Update
function UpdateCategory() {
    var res = ValidateUpdate();
    if (res == false) {
        return false;
    }

    var objData = new Object();
    objData.id = $('#CategoryEditModal #Id').val();
    objData.name = $('#CategoryEditModal #Name').val();

    $.ajax({
        url: '/Category/Edit',
        data: objData,
        type: 'POST',
        success: function (result) {
            if (result.success === true) {
                HideEditModal();
                ShowCategoryData();
                toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}

function HideEditModal() {
    $('#CategoryEditModal').modal('hide');
    $('#CategoryEditModal #Name').css('border-color', '#ced4da');
    $('#CategoryEditModal #errorIcon').css('display', 'none');
}

function ValidateUpdate() {
    var isValid = true;

    if ($('#CategoryEditModal #Name').val().trim() == "") {
        $('#CategoryEditModal #Name').css('border-color', '#dc3545');
        $('#CategoryEditModal #errorIcon').css('display', 'block');
        isValid = false;
    }
    return isValid;
}

function OnKeyUpEdit() {
    $('#CategoryEditModal #Name').css('border-color', 'lightgrey');
    $('#CategoryEditModal #errorIcon').css('display', 'none');
}

// Bắt sự kiện nhấn nút Esc
function CloseCategoryEditModal(evt) {
    if (evt.keyCode == 27) {
        HideEditModal();
    }
}
