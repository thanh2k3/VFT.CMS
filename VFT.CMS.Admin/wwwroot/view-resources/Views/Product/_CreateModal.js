function CreateProduct() {
    $('#formCreateProduct').validate({
        errorPlacement: function (error, element) {
            return true;
        },
    })

    $('#formCreateProduct').addClass('was-validated')

    var isValid = $("#formCreateProduct").valid();
    if (!isValid)
        return

    var formData = new FormData();
    formData.append('Name', $('#ProductCreateModal #Name').val());
    formData.append('CategoryId', $('#ProductCreateModal #CategoryId').find('option:selected').val());
    formData.append('Price', ($('#ProductCreateModal #Price').val()).replaceAll('.', ''));
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
                dataTable.ajax.reload();
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

function ClearTextBoxProductCreate() {
    $('#ProductCreateModal #Name').val('');
    $('#ProductCreateModal #CategoryId').prop('selectedIndex', 0)
    $('#ProductCreateModal #Price').val('');
    $('#ProductCreateModal #Description').val('');
    $('#ProductCreateModal #Image').val('');
}


function HideProductCreateModal() {
    ClearTextBoxProductCreate();
    $('#ProductCreateModal').modal('hide');
    $('#formCreateProduct').removeClass('was-validated');
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