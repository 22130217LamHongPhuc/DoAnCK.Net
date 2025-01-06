function AddToCart() {
    alert('start')
    var productId = $(this).data("product-id");
    var name = $(this).data("name");
    var price = $(this).data("price");
    var discount = $(this).data("discount");
    var thumbnail = $(this).data("thumbnail");

    var quantity = $(this).data("quality");

    alert(productId + " " + name + " " + price + " " + discount + " " + thumbnail + " " quantity);

    $.ajax({
        url: '@Url.Action("AddToCart", "Cart")',
        type: 'POST',
        data: {
            productId: productId,
            name: name,
            price: price,
            discount: discount,
            thumbnail: thumbnail,
            quantity: quantity
        },
        success: function (response) {


            alert(response);

        },
        error: function () {
            alert('Đã có lỗi xảy ra!');
        }
    });
}