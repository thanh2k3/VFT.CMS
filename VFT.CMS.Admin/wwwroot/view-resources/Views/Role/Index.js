$(document).ready(function () {
    ShowRoleData();

    $('#RoleCreateModal .modal-title').text("Thêm mới Quyền");

    $('#tableRole_length').addClass('pt-3 pl-4');
    $('#tableRole_filter').addClass('pt-3 pr-4');
    $('#tableRole_info').addClass('mt-2 pl-4');
    $('#tableRole_paginate').addClass('pb-3 pr-4 pt-3');
})

function ShowRoleData() {
    $('#tableRole').DataTable({
        language: {
            lengthMenu: 'Hiển thị _MENU_ bản ghi',
            search: 'Tìm kiếm:',
            info: 'Hiển thị _START_ đến _END_ của _TOTAL_ bản ghi',
            infoEmpty: 'Chưa có bản ghi nào để hiển thị',
            paginate: {
                previous: 'Trước',
                next: 'Sau',
            },
            emptyTable: 'Chưa có dữ liệu, vui lòng thêm dữ liệu vào',
        },
        processing: true,
        serverSide: true,
        ordering: false,
        filter: true,
        ajax: {
            url: '/Role/GetRoles',
            type: 'POST',
            dataType: 'json'
        },
        columns: [
            {
                data: 'name',
                autoWidth: true
            },
            {
                data: 'description',
                autoWidth: true,
                render: function (data) {
                    return '<td>' + (data ? data : "-") + '</td>'
                }
            },
            {
                data: 'id',
                render: function (data) {
                    return '<a class="btn btn-warning btn-sm" onclick="ShowRoleEditData(' + data + ')"><i class="fas fa-pencil-alt"></i> Sửa</a>' +
                        ' <a class="btn btn-danger btn-sm" onclick="DeleteRole(' + data + ')"><i class="fas fa-trash"></i> Xóa</a></td >'
                }
            },
        ]
    })
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