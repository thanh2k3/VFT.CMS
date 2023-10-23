var defaultOption = $('#ProductCreateModal #CategoryId').find('option:selected').text();

$(document).ready(function () {
    ShowProductData();

    $('#ProductCreateModal .modal-title').text('Thêm mới sản phẩm');
})

function ShowProductData() { debugger
    $.ajax({
        url: '/Product/GetData',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (result) { debugger
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.name + '</td>';
                object += '<td>' + item.category.name + '</td>';
                object += '<td>' + item.image + '</td>';
                object += '<td>' + item.price + '</td>';
                object += '<td>' + item.description + '</td>';
                object += '<td class="text-center"><a class="btn btn-info btn-sm" onclick="ViewProductModal(' + item.id + ')"><i class="fa-solid fa-eye"></i> Xem</a>' +
                    ' <a class="btn btn-warning btn-sm" onclick="GetProductEditData(' + item.id + ')"><i class="fas fa-pencil-alt"></i> Sửa</a>' +
                    ' <a class="btn btn-danger btn-sm" onclick="DeleteProduct(' + item.id + ')"><i class="fas fa-trash"></i> Xóa</a></td>';
                object += '</tr>';
            });
            $('#tblProductBody').html(object);
        }
    });
}

// Partial View Edit
function GetProductEditData(id) {
    $.ajax({
        url: '/Product/Edit?id=' + id,
        type: 'GET',
        contentType: 'application/html;charset=utf-8',
        dataType: 'html',
        success: function (result) {
            if (result != null || result != undefined) {
                $('#ProductEditModal').find('.modal-content').html(result);
                $('#ProductEditModal').find('#CategoryId option:first').css('display', 'none');
                $('#ProductEditModal').modal('show');
                $('#ProductEditModal .modal-title').text('Sửa sản phẩm');
            } else {
                toastr.error(null, "không thể đọc dữ liệu", { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

// Delete Product
function DeleteProduct(id) {
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
                url: '/Product/Delete?id=' + id,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    if (result.success === true) {
                        ShowProductData();
                        toastr.info(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    } else {
                        toastr.error(result.message, null, { timeOut: 3000, positionClass: 'toast-bottom-right' });
                    }
                }
            });
        }
    })
}

// View Modal
function ViewProductModal(id) {
    $.ajax({
        url: '/Product/ViewModal?id=' + id,
        type: 'GET',
        contentType: 'application/html;charset=utf-8',
        dataType: 'html',
        success: function (result) {
            if (result != null || result != undefined) {
                $('#ProductViewModal').find('.modal-content').html(result);
                $('#ProductViewModal').modal('show');
                $('#ProductViewModal').find('.modal-title').text("Xem sản phẩm");
            }
        }
    });
}