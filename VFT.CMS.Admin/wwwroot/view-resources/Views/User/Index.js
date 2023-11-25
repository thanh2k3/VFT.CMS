$(document).ready(function () {
    var dataTable;

    ShowUserData();

    $('#UserCreateModal .modal-title').text("Thêm mới Người dùng");

    $('#tableUser_length').addClass('pt-3 pl-4');
    $('#tableUser_filter').addClass('pt-3 pr-4');
    $('#tableUser_info').addClass('mt-2 pl-4');
    $('#tableUser_paginate').addClass('pb-3 pr-4 pt-3');
})

function ShowUserData() {
    dataTable = $('#tableUser').DataTable({
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
            url: '/User/GetUsers',
            type: 'POST',
            dataType: 'json'
        },
        columns: [
            {
                data: 'fullName',
                name: 'FullName',
                autoWidth: true
            },
            {
                data: 'email',
                name: 'Email',
                autoWidth: true
            },
            {
                data: 'avatar',
                name: 'Avatar',
                render: function (data) {
                    return '<img class="img-responsive img-thumbnail" src="' + data + '" alt="Image" height="50px" width="50px" />'
                }
            },
            {
                data: 'birthday',
                name: 'Birthday',
                render: function (data) {
                    return '<td>' + (data ? new Date(data).toLocaleDateString("en-AU") : "-") + '</td>'
                }
            },
            {
                data: 'id',
                render: function (data) {
                    return '<a class="btn btn-info btn-sm" onclick="ShowUserViewModal(' + data + ')"><i class="fa-solid fa-eye"></i> Xem</a>' +
                        ' <a class="btn btn-warning btn-sm" onclick="ShowUserEditData(' + data + ')"><i class="fas fa-pencil-alt"></i> Sửa</a>' +
                        ' <a class="btn btn-danger btn-sm" onclick="DeleteUser(' + data + ')"><i class="fas fa-trash"></i> Xóa</a></td >'
                },
                searchable: false
            },
        ],
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
                //$('#UserEditModal').find('.modal-title').text("Sửa " + "[" + id + "]");
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
                        dataTable.ajax.reload();
                        toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    } else {
                        toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    }
                }
            });
        }
    })
}