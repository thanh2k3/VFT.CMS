// View Edit
function GetCategoryEditData(id) {
    $.ajax({
        url: '/Category/Edit?id=' + id,
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (res) {
            if (res != null || res != undefined) {
                $('#CategoryEditModal').modal('show');
                $('#CategoryEditModal #Title').text('Sửa danh mục');
                $('#CategoryEditModal #Id').val(res.id);
                $('#CategoryEditModal #Name').val(res.name);
            } else {
                toastr.error(null, "không thể đọc dữ liệu", { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

// Update
function UpdateCategory() {
    var result = ValidateUpdate();
    if (result == false) {
        return false;
    }

    var objData = new Object();
    objData.id = $('#CategoryEditModal #Id').val();
    objData.name = $('#CategoryEditModal #Name').val();

    $.ajax({
        url: '/Category/Edit',
        data: objData,
        type: 'POST',
        success: function (res) {
            if (res.success === true) {
                HideEditModal();
                ShowCategoryData();
                toastr.info(res.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            } else {
                toastr.error(res.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
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
