$(document).ready(function () {
    new Orderdetail();
})
class Orderdetail {
    constructor() {
        this.initEvent();
    }

    initEvent() {
        $(document).on('click', '.btn-Detiail', this.showDetail);
    }


    /**
     * show chi tiêt danh sách
     * 
     * */
    showDetail() {

        let idOrder = $(this).attr('Id');

        var settings = {
            "url": "https://localhost:44301/Order/" + idOrder,
            "method": "GET",
            "timeout": 0,
        };

        $('.btn-body').empty();
        $.ajax(settings).done(function (response) {
            debugger
            $.each(response, function (index, res) {
                debugger
                var item = ` <div class="content-detail">
                        <div style="display:flex">
                            <div>ID: </div>
                            <div style="padding-left:25px">${res.id}</div>
                        </div>
                        <div style="display:flex">
                            <div>Giá: </div>
                            <div style="padding-left:25px">${res.price}</div>
                        </div>
                        <div style="display:flex">
                            <div>Mã sản phẩm: </div>
                            <div style="padding-left:25px">${res.code}</div>
                        </div>
                        <div style="display:flex">
                            <div>Tên sản phẩm: </div>
                            <div style="padding-left:25px">${res.name}</div>
                        </div>
                        <div style="display:flex">
                            <div>Tên: </div>
                            <div style="padding-left:25px">${res.shipName}</div>
                        </div>
                        <div style="display:flex">
                            <div>Email: </div>
                            <div style="padding-left:25px">${res.shipEmail}</div>
                        </div>
                        <div style="display:flex">
                            <div>Số điện thoại: </div>
                            <div style="padding-left:25px"> ${res.shipMobile}</div>
                        </div>
                    </div>
                    <hr />`;
                $('.btn-body').append(item);
            })
        });
    }
}