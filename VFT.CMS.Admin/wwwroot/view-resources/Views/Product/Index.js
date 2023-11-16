var defaultOption = $('#ProductCreateModal #CategoryId').find('option:selected').text();

$(document).ready(function () {
    ShowProductData();

    $('#ProductCreateModal .modal-title').text('Thêm mới sản phẩm');

    $('#tableProduct_length').addClass('pt-3 pl-4');
    $('#tableProduct_filter').addClass('pt-3 pr-4');
    $('#tableProduct_info').addClass('mt-2 pl-4');
    $('#tableProduct_paginate').addClass('pb-3 pr-4 pt-3');
})

function ShowProductData() {
    let USDollar = new Intl.NumberFormat();
    dataTable = $('#tableProduct').DataTable({
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
            url: '/Product/GetProducts',
            type: 'POST',
            dataype: 'json'
        },
        columns: [
            {
                data: 'name',
                name: 'Name',
                autoWidth: true
            },
            {
                data: 'category.name',
                autoWidth: true
            },
            {
                data: 'image',
                name: 'Image',
                render: function (data, type, row, meta) {
                    return '<img class="img-responsive img-thumbnail" src="' + data + '" alt="Image" height="50px" width="50px" />';
                }
            },
            {
                data: 'price',
                name: 'Price',
                autoWidth: true,
                render: function (data, type, row, meta) {
                    return USDollar.format(data)
                }
            },
            {
                data: 'description',
                name: 'Description',
                autoWidth: true
            },
            {
                data: 'id',
                render: function (data) {
                    return '<a class="btn btn-info btn-sm" onclick="ShowViewProductData(' + data + ')"><i class="fa-solid fa-eye"></i> Xem</a>' +
                        ' <a class="btn btn-warning btn-sm" onclick="ShowProductEditData(' + data + ')"><i class="fas fa-pencil-alt"></i> Sửa</a>' +
                        ' <a class="btn btn-danger btn-sm" onclick="DeleteProduct(' + data + ')"><i class="fas fa-trash"></i> Xóa</a></td >'
                },
                searchable: false
            },
        ],
    });
}

// View
function ShowViewProductData(id) {
    $.ajax({
        url: '/Product/ViewModal?id=' + id,
        type: 'GET',
        contentType: 'application/html;charset=utf-8',
        dataType: 'html',
        success: function (result) {
            if (result != null || result != undefined) {
                $('#ProductViewModal').find('.modal-content').html(result);
                $('#ProductViewModal').modal('show');
                $('#ProductViewModal').registerInputAmount();
                $('#ProductViewModal').find('.modal-title').text("Xem sản phẩm");
            }
        }
    });
}

// Edit
function ShowProductEditData(id) {
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
                $('#ProductEditModal').find('form').registerInputAmount();
                $('#ProductEditModal .modal-title').text('Sửa sản phẩm');
            } else {
                toastr.error(null, "không thể đọc dữ liệu", { timeOut: 3000, positionClass: 'toast-bottom-right' });
            }
        }
    });
}

// Delete
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

(function ($) {
    var _$modal = $('#ProductCreateModal'),
        _$form = _$modal.find('form');

    _$form.registerInputAmount();
})(jQuery);