$(document).ready(function () {
    ShowCategoryData();

    $('#CategoryCreateModal .modal-title').text('Thêm mới Danh mục');
})

// View
function ShowCategoryData() {
    $.ajax({
        url: "/Category/GetData",
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.name + '</td>';
                object += '<td class="text-center"><a class="btn btn-warning btn-sm" onclick="GetCategoryEditData(' + item.id + ')"><i class="fas fa-pencil-alt"></i> Sửa</a>' +
                    ' <a class="btn btn-danger btn-sm" onclick="DeleteCategory(' + item.id + ')"><i class="fas fa-trash"></i> Xóa</a></td>';
                object += '</tr>';
            });
            $('#tblCategoryBody').html(object);
        },
        error: function () {
            alert("Không thể lấy dữ liệu");
        }
    });
}

// View Edit
function GetCategoryEditData(id) {
    $.ajax({
        url: '/Category/Edit?id=' + id,
        type: 'GET',
        contentType: 'application/html;charset=utf-8',
        dataType: 'html',
        success: function (result) {
            if (result != null || result != undefined) {
                $('#CategoryEditModal').find('.modal-content').html(result);
                $('#CategoryEditModal .modal-title').text('Sửa Danh mục');
                $('#CategoryEditModal').modal('show');
            } else {
                toastr.error(null, "không thể đọc dữ liệu", { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

// Delete Category
function DeleteCategory(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "Bạn sẽ không thể hoàn tác khi đã xóa",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Đồng ý',
        cancelButtonText: 'Hủy',
        reverseButtons: true
    }).then((res) => {
        if (res.isConfirmed) {
            $.ajax({
                url: '/Category/Delete?id=' + id,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    if (result.success === true) {
                        ShowCategoryData();
                        toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    } else {
                        toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    }
                }
            });
        }
    })
}

// Bắt sự kiện nhấn nút Enter không load lại trang
function EnterNoLoad() {
    return false;
}