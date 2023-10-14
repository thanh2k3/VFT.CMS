$(document).ready(function () {
    ShowCategoryData();

    $('#CategoryCreateModal #Title').text('Tạo danh mục');

    $("#CategoryEditModal #Name").keypress(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            UpdateCategory();
        }
    });

    $("#CategoryCreateModal #Name").keypress(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            CreateCategory();
        }
    });
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
                    ' <a class="btn btn-danger btn-sm" onclick="GetCategoryDeleteData(' + item.id + ')"><i class="fas fa-trash"></i> Xóa</a></td>';
                object += '</tr>';
            });
            $('#tblBody').html(object);
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
                $('#CategoryEditModal #Title').text('Sửa danh mục');
                $('#CategoryEditModal').modal('show');
            } else {
                toastr.error(null, "không thể đọc dữ liệu", { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

// View Delete
function GetCategoryDeleteData(id) {
    $.ajax({
        url: '/Category/Delete?id=' + id,
        type: 'GET',
        contentType: 'application/html;charset=utf-8',
        dataType: 'html',
        success: function (result) {
            if (result != null || result != undefined) {
                $('#CategoryDeleteModal').find('.modal-content').html(result);
                $('#CategoryDeleteModal #Title').text('Xác nhận xóa danh mục');
                $('#CategoryDeleteModal').modal('show');
            } else {
                toastr.error(null, "không thể đọc dữ liệu", { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

// Bắt sự kiện nhấn nút Enter không load lại trang
function EnterNoLoad() {
    return false;
}