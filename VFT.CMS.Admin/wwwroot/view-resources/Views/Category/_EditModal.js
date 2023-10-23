// Update
function UpdateCategory() {
    var res = ValidateCategoryUpdate();
    if (res == false) {
        return false;
    }

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
                HideCategoryEditModal();
                ShowCategoryData();
                toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}

function HideCategoryEditModal() {
    $('#CategoryEditModal').modal('hide');
    $('#CategoryEditModal #Name').css('border-color', '#ced4da');
    $('#CategoryEditModal #errorIcon').css('display', 'none');
}

function ValidateCategoryUpdate() {
    var isValid = true;

    if ($('#CategoryEditModal #Name').val().trim() == "") {
        $('#CategoryEditModal #Name').css('border-color', '#dc3545');
        $('#CategoryEditModal #errorIcon').css('display', 'block');
        isValid = false;
    }

    return isValid;
}

function OnKeyUpCategoryEdit() {
    $('#CategoryEditModal #Name').css('border-color', '#ced4da');
    $('#CategoryEditModal #errorIcon').css('display', 'none');
}