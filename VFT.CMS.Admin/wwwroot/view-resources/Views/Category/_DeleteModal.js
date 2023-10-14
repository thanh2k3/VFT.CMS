// Delete
function DeleteCategory() {
    var objData = new Object();
    objData.id = $('#CategoryDeleteModal #Id').val();
    objData.name = $('#CategoryDeleteModal #Name').val();

    $.ajax({
        url: '/Category/Delete',
        data: objData,
        type: 'POST',
        success: function (result) {
            if (result.success === true) {
                HideDeleteModal();
                ShowCategoryData();
                toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            } else {
                toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' })
            }
        }
    });
}

function HideDeleteModal() {
    $('#CategoryDeleteModal').modal('hide');
}