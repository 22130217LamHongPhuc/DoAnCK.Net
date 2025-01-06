function showFormExport (checkbox){
    var form =document.getElementById('form-bill-export');
    if(checkbox.checked){
        form.style.display='block'
    }else{
        form.style.display='none'

    }
}

function changeQuantity(button) {
    console.log('start1')
   
    var quantityElement = $(button).siblings('span.quality-product');

    var productItem = $(button).closest('.product-item');
    console.log(3 + "");

    var currentQuantity = parseInt(quantityElement.text());

    console.log(4 + "");


    var newQuantity;
    //currentQuantity = (isIncrement) ? ++currentQuantity : --currentQuantity;
    newQuantity = ++currentQuantity;

    console.log(newQuantity + "");


    $.ajax({
        url: '/Cart/UpdateQuantity', 
        type: 'POST',
        data: {
            productId: 'MHCBCDN01.NU15', 
            quatity: 10
        },
        success: function (response) {
            if (response.success) {
                
                //quantityElement.text(response.newQuantity);
                //productItem.find('.total-price').text(response.TotalPriceCart);

                alert(response.TotalPriceItem + " " + response.TotalPriceCart)
            } else {
                alert("Cập nhật số lượng thất bại!");
            }
        },
        error: function () {
            alert('Đã có lỗi xảy ra trong quá trình cập nhật!');
        }
    });
}
