// View Delete
function GetCategoryDeleteData(id) {
    $.ajax({
        url: '/Category/Edit?id=' + id,
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (res) {
            if (res != null || res != undefined) {
                $('#CategoryDeleteModal').modal('show');
                $('#CategoryDeleteModal #Title').text('Xác nhận xóa danh mục');
                $('#CategoryDeleteModal #Id').val(res.id);
                $('#CategoryDeleteModal #Name').val(res.name);
            } else {
                toastr.error(null, "không thể đọc dữ liệu", { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

// Delete
function DeleteCategory() {
    var objData = new Object();
    objData.id = $('#CategoryDeleteModal #Id').val();
    objData.name = $('#CategoryDeleteModal #Name').val();

    $.ajax({
        url: '/Category/Delete',
        data: objData,
        type: 'POST',
        success: function (res) {
            if (res.success === true) {
                HideDeleteModal();
                ShowCategoryData();
                toastr.info(res.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            } else {
                toastr.error(res.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}

function HideDeleteModal() {
    $('#CategoryDeleteModal').modal('hide');
}