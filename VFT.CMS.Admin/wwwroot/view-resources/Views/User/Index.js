$(document).ready(function () {
    $('#UserCreateModal .modal-title').text("Thêm mới Người dùng");

    ShowUserData();
})

function ShowUserData() {
    $.ajax({
        url: '/User/GetData',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.fullName + '</td>';
                object += '<td>' + item.userName + '</td>';
                object += '<td>' + item.avatar + '</td>';
                object += '<td>' + item.email + '</td>';
                object += '<td>' + item.birthday + '</td>';
                object += '<td>' + item.createdDate + '</td>';
                object += '<td class="text-center"><a class="btn btn-info btn-sm" onclick="ShowUserViewModal(' + item.id + ')"><i class="fa-solid fa-eye"></i> Xem</a>' +
                    ' <a class="btn btn-warning btn-sm" onclick="ShowUserEditData(' + item.id + ')"><i class="fas fa-pencil-alt"></i> Sửa</a>' +
                    ' <a class="btn btn-danger btn-sm" onclick="DeleteUser(' + item.id + ')"><i class="fas fa-trash"></i> Xóa</a></td>';
                object += '</tr>';
            });
            $('#tblUserBody').html(object);
        }
    });
}

function ShowUserEditData(id) {
    $.ajax({
        url: '/User/Edit?id=' + id,
        type: 'GET',
        contentType: 'application/html;charset=utf-8',
        dataType: 'html',
        success: function (result) {
            if (result != null || result != undefined) {
                $('#UserEditModal').find('.modal-content').html(result);
                $('#UserEditModal').modal('show');
                $('#UserEditModal').find('.modal-title').text("Sửa " + "[" + id + "]");
            } else {
                toastr.error(null, "không thể đọc dữ liệu", { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    })
}

function ShowUserViewModal(id) {
    $.ajax({
        url: '/User/ViewModal?id=' + id,
        type: 'GET',
        contentType: 'application/html;charset=utf-8',
        dataType: 'html',
        success: function (result) {
            if (result != null || result != undefined) {
                $('#UserViewModal').find('.modal-content').html(result);
                $('#UserViewModal').modal('show');
                $('#UserViewModal').find('.modal-title').text("Xem " + "[" + id + "]");
            }
        }
    });
}

function DeleteUser(id) {
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
                url: '/User/Delete?id=' + id,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    if (result.success === true) {
                        ShowUserData();
                        toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    } else {
                        toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    }
                }
            });
        }
    })
}