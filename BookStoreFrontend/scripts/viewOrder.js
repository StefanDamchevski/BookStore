//get input data
function viewOrder(){
    let orderCode = document.getElementById("customerOrderCode").value;
    let email = document.getElementById("customerEmail").value;
    
    let isValid = validateInputFields();
    if(!isValid){
        alert("Input Fields Required!!!");
        return null;
    }else{
        getOrderDetails(orderCode,email);
    }
}

function clearInputFields(){
    let orderCode = document.getElementById("customerOrderCode").value = "";
    let email = document.getElementById("customerEmail").value = "";
}

function validateInputFields(){
    let isValid = true;
    let inputFields = document.querySelectorAll('.form-control');

    for (let i = 0; i < inputFields.length; i++) {
        if(inputFields[i].value == ""){
            isValid = false;
            break;
        }
    }
    return isValid;
}

//show order

function getOrderDetails(orderCode,email){
    axios.get(`https://localhost:44342/api/orders/details/?email=${email}&orderCode=${orderCode}`, {
    })
    .then(function (response) {
        clearInputFields();
        showOrder(response.data);
    })
    .catch(function (error) {
        console.log(error);
    });
}

function showOrder(orderDetails){
    let container = document.getElementById("rowContainer");
    container.classList.add("orderDetails");

    let card = document.createElement("div");
    container.appendChild(card);

    let cardEmail = document.createElement("h4");
    cardEmail.innerHTML = `Email: ${orderDetails.email}`;
    card.appendChild(cardEmail);

    let cardOrderCode = document.createElement("h4");
    cardOrderCode.innerHTML = `Order Code: ${orderDetails.orderCode}`;
    card.appendChild(cardOrderCode);

    for (let i = 0; i < orderDetails.books.length; i++) {

        let cardBooks = document.createElement("div");
        cardBooks.classList.add("bookCard");
        card.appendChild(cardBooks);
        
        let bookTitle = document.createElement("h4");
        bookTitle.innerHTML = `Title: ${orderDetails.books[i].title}`;
        cardBooks.appendChild(bookTitle);

        let bookAuthor = document.createElement("h4");
        bookAuthor.innerHTML = `Author: ${orderDetails.books[i].author}`;
        cardBooks.appendChild(bookAuthor);

        let bookPrice = document.createElement("h4");
        bookPrice.innerHTML = `Price: ${orderDetails.books[i].price}`;
        cardBooks.appendChild(bookPrice);

    }

    let cardOrderFullPrice = document.createElement("h4");
    cardOrderFullPrice.innerHTML = `Full Price: ${orderDetails.fullPrice}`;
    card.appendChild(cardOrderFullPrice);
}