$(document).ready(function () {
    ShowRoleData();

    $('#RoleCreateModal .modal-title').text("Thêm mới Quyền");
})

function ShowRoleData() {
    $.ajax({
        url: '/Role/GetData',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.name + '</td>';
                object += '<td>' + item.description + '</td>';
                object += '<td class="text-center"><a class="btn btn-warning btn-sm" onclick="ShowRoleEditData(' + item.id + ')"><i class="fas fa-pencil-alt"></i> Sửa</a>' +
                    ' <a class="btn btn-danger btn-sm" onclick="DeleteRole(' + item.id + ')"><i class="fas fa-trash"></i> Xóa</a></td>';
                object += '</tr>';
            });
            $('#tblRoleBody').html(object);
        },
        error: function () {
            alert('Không thể lấy dữ liệu');
        }
    });
}

//View Edit
function ShowRoleEditData(id) {
    $.ajax({
        url: '/Role/Edit?id=' + id,
        type: 'GET',
        contentType: 'application/html;charset=utf-8',
        dataType: 'html',
        success: function (result) {
            if (result != null || result != undefined) {
                $('#RoleEditModal').find('.modal-content').html(result);
                $('#RoleEditModal .modal-title').text('Sửa quyền');
                $('#RoleEditModal').modal('show');
            } else {
                toastr.error(null, "không thể đọc dữ liệu", { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    })
}

function DeleteRole(id) {
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
                url: '/Role/Delete?id=' + id,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    if (result.success === true) {
                        ShowRoleData();
                        toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    } else {
                        toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    }
                }
            })
        }
    })
}

// Bắt sự kiện nhấn nút Enter không load lại trang
function EnterNoLoad() {
    return false;
}