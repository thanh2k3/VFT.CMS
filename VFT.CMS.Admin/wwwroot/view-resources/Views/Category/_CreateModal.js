function CreateCategory() {
    $('#formCreateCategory').validate({
        errorPlacement: function (error, element) {
            return true;
        },
    })

    $('#formCreateCategory').addClass('was-validated')

    var isValid = $("#formCreateCategory").valid();
    if (!isValid)
        return

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
    $('#formCreateCategory').removeClass('was-validated');
}

function ClearTextBoxCategoryCreate() {
    $('#CategoryCreateModal #Name').val('');
}

// Bắt sự kiện nhấn nút Esc
function EscCategoryCreateModal(evt) {
    if (evt.keyCode == 27) {
        HideCategoryCreateModal();
    }
}