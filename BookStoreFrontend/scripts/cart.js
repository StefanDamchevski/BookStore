function initCart(){
    let cartItems = storageService.getFromLocalStorage("cartItems");
    for (let i = 0; i < cartItems.length; i++) {
        axios.get(`https://localhost:44342/api/books/${cartItems[i]}`)
      .then(function (response) {
        createCartItem(response.data);
      })
      .catch(function (error) {
        console.log(error);
      });
    } 
}

function clearInputFields(){
    let name = document.getElementById("customerName").value = "";
    let email = document.getElementById("customerEmail").value = "";
    let adress = document.getElementById("customerAddress").value = "";
    let phone = document.getElementById("customerPhone").value = "";
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

function createCartItem(book){
    let container = document.getElementById("rowContainer");

    let card = document.createElement("div");
    card.classList.add("bookCard");
    container.appendChild(card);

    let cardTitle = document.createElement("h4");
    cardTitle.innerHTML = `Title: ${book.title} - Author: ${book.author}`;
    card.appendChild(cardTitle);

    let cardPrice = document.createElement("h4");
    cardPrice.innerHTML = `Price: ${book.price}`;
    card.appendChild(cardPrice);

    let cardBtn = document.createElement("button");
    cardBtn.classList.add("btn");
    cardBtn.classList.add("btn-primary");
    cardBtn.innerHTML = "Remove from cart";
    cardBtn.onclick = function (e) { removeFromCart(e, book.id);};    
    card.appendChild(cardBtn);
}

function removeFromCart(event, bookId){
    storageService.removeFromLocalStorage(bookId,"cartItems");
    event.target.parentElement.remove();
}

function orderBooks(){
    let name = document.getElementById("customerName").value;
    let email = document.getElementById("customerEmail").value;
    let address = document.getElementById("customerAddress").value;
    let phone = document.getElementById("customerPhone").value;

    let isValid = validateInputFields();

    if(!isValid){
        alert("Please fill the input fields!!");
        clearInputFields();
    }else{
        createNewOrder(name,email,address,phone);
    }
}

function createNewOrder(name,email,address,phone){
    //get storage data
    let storageData = storageService.getFromLocalStorage("cartItems");

    if(storageData.length > 0){
        axios.post('https://localhost:44342/api/Orders', {
            name : name,
            email : email,
            address : address,
            phone : phone,
            bookIds : storageData
          })
          .then(function (response) {
            storageService.clearStorage("cartItems");
            alert(`Your order code is: ${response.data.orderCode}`);
            location.href = "./index.html";
          })
          .catch(function (error) {
            console.log(error);
          });
    }
}

initCart();