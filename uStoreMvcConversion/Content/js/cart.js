//js object notation JSON to store book info
var products = [
    {
        id: 1,
        desc: "Product 1 Decsription",
        brand: "Product 1 Brand",
        price: 9.99
    },
    {
        id: 2,
        desc: "Product 2 Decsription",
        brand: "Product 2 Brand",
        price: 19.99
    },
    {
        id: 3,
        desc: "Product 3 Decsription",
        brand: "Product 3 Brand",
        price: 29.99
    },
{
    id: 4,
    desc: "Product 4 Decsription",
    brand: "Product 4 Brand",
    price: 39.99
},
{
    id: 5,
    desc: "Product 5 Description",
    brand: "Product 5 Brand",
    price: 49.99
},
{
    id: 6,
    desc: "Product 6 Description",
    brand: "Product 6 Brand",
    price: 59.99
}
//{
//    id: 4,
//    title: "The Maze Runner",
//    author: "James Dashner",
//    price: 7.65
//},
//{
//    id: 5,
//    title: "Macbeth",
//    author: "William Shakespheare",
//    price: 6.50
//},
//{
//    id: 6,
//    title: "Triumph",
//    author: "Jeremy Schaap",
//    price: 11.45
//}
];

//Create an array to store the users cart info

var cart = [];

//add items to the cart == wired to <a> in html

function addToCart(id) {
    //if the user has not added any of the titles yet, set the quantity to 1 and add the book to the array. 
    //otherwise, set 1 to qty.
    var productObj = products[id - 1];
    if (typeof productObj.qty === 'undefined') {
        productObj.qty = 1;
        cart.push(productObj); //adding item to an existing array
    } else {
        productObj.qty = productObj.qty + 1;
        //bookObj.qty = bookObj.qty++;
        //bookObj.qty += 1;
        //refactored code from line 55
    }
    //testing purposes only
    console.clear();
    var arrayLength = cart.length;
    for (var i = 0; i < arrayLength; i++) {
        console.log(cart[i]);
    }
    document.getElementById('cart-notification').style.display = 'block';

    //get total num of books in cart
    var cartQty = 0;
    for (var i = 0; i < arrayLength; i++) {
        cartQty += cart[i].qty;
    }

    document.getElementById('cart-notification').innerHTML = cartQty;
    document.getElementById('cart-contents').innerHTML = getCartContents();
}

function getCartContents() {
    var cartContent = "";
    var cartTotal = 0;

    //mini lab
    //display the title author qty price and total price of all cart contents
    for (var i = 0; i < cart.length; i++) {
        cartContent += cart[i].desc + '<br/>By: ' + cart[i].brand + '<br/>$ ' + cart[i].price + '<br/>Qty: ' + cart[i].qty + '<br/>';
        cartTotal += cart[i].qty * cart[i].price;
    }
    cartContent += '<br/>Cart Total $' + cartTotal.toFixed(2);
    return cartContent;
}

