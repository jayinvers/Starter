jQuery.fn.dataTable = function () {

};



function update(productId, field, value) {
    const myCart = $.parseJSON(localStorage.cart);
    $.each(myCart, function (index, item) {

        if (item.productId == productId)
                item[field] = value;
    });

    localStorage.cart = JSON.stringify(myCart);

}


function handleQuantity(productId,oprator) {
    let quantity = $("#quantity" + productId).text();
    if (oprator == "sub")
        quantity = parseInt(quantity) - 1;
    else
        quantity = parseInt(quantity) + 1;

    if (quantity < 1)
        quantity = 0;

    $("#quantity" + productId).html(quantity);
    update(productId, "quantity", quantity);
    updateCartView();

}



const addCartItemToTable = function (index, productId, productName, quantity, price) {
    let html = '<tr><th scope = "row">' + (parseInt(index)+ 1) + '</th>';
    html += '<td>' + productName +'</td>';
    html += '<td><button data-id="1" onClick="handleQuantity(' + productId + ',\'sub\')" id="sub' + productId + '" class="btn">-</button><span class="ms-1 me-1" id="quantity' + productId + '">' + quantity + '</span><button  onClick="handleQuantity(' + productId + ',\'plus\')" id="' + productId +'" class="btn">+</button></td>';
    html += '<td id="price' + productId +'">$' + price + '</td></tr >';

    return html;
}


const updateCartView = function () {
    const myCart = $.parseJSON(localStorage.cart);
    let total = 0;
    $("#CartDetail table tbody").html("");
    $.each(myCart, function (index, item) {
        $("#CartDetail table tbody").append(addCartItemToTable(index, item.productId, item.productName, item.quantity, item.price * item.quantity));
        total += item.price * item.quantity
    });
    $("#CartDetail table tbody").append('<tr><th scope="row" colspan="3">Total: (Inc.GST)</th> <td class="fw-bold">$' + total + '</td> </tr>')
}



// when windows loaded
$(document).ready(function () {
    updateCartView();
});