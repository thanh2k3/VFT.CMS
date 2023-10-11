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

function ShowCategoryData() {
    debugger
    $.ajax({
        url: "/Category/GetData",
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            debugger
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

// Bắt sự kiện nhấn nút Enter không load lại trang
function EnterNoLoad() {
    return false;
}