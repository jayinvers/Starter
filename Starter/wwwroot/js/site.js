const cars = '{"data":["Saab", "BMW", "Benz", "Jay"]}';

const tr = function (html) {
    return "<tr>" + html + "</tr>"
}

const hasProductId = function (cartJson, productId) {
    let isExeist = false;
    $.each(cartJson, function (index, item) {

        if (item.productId == productId && isExeist == false) {
      //      alert(productId + " : " + item.productId);
            cartJson[index].quantity += 1;
            localStorage.cart = JSON.stringify(cartJson);
            isExeist = true;
        }
    });
    return isExeist;
}

const addCart = function (productId, productName, price) {
    const myCart = $.parseJSON(localStorage.cart)
    if (!hasProductId(myCart, productId)) {
        let item = { "productId": productId, "productName": productName, "price": price, "quantity": 1 };
        if (myCart != null) {
            myCart.push(item);
            localStorage.cart = JSON.stringify(myCart);
        }
    }
}


const updateCart = function () {
    if (localStorage.cart != null) {
        const myCart = $.parseJSON(localStorage.cart);
        $("#cart tbody").html("");

        $.each(myCart, function (index, item) {
            $("#cart tbody").append(tr('<td>' + item.productName + "</td><td>" + item.quantity + '</td><td>$'+ item.quantity * item.price + '</td>'));
        });
        $("#dropdownMenuButton").html("Cart(" + myCart.length + ")");
    }

}

// bind Click for AddToCart
$("#addtocart").click(function () {

    addCart(this.dataset.productId, this.dataset.productName, this.dataset.price);
    updateCart();

    const cartToast = $("#cartToast");
    $("#cartToast div.toast-body").html(this.dataset.productName + " has been added to the cart");
    const toast = new bootstrap.Toast(cartToast);
    toast.show();
});


// when windows loaded
$(document).ready(function () {
    //  localStorage.cart = cars;
    if (localStorage.cart == null)
        localStorage.cart = "[]"

    updateCart();

});
