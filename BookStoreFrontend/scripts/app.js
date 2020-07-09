axios.get('https://localhost:44342/api/books')
  .then(function (response) {
    response.data.forEach(book => {
        createBookCard(book);
    });
  })
  .catch(function (error) {
    console.log(error);
  });

  function createBookCard(book){
        let row = document.getElementById("rowContainer");

        let colMd = document.createElement("div");
        colMd.classList.add("col-md-3");
        row.append(colMd);

        let card = document.createElement("div");
        card.classList.add("card");
        colMd.appendChild(card);

        let cardBody = document.createElement("div");
        cardBody.classList.add("card-body");
        card.appendChild(cardBody);
        
        const titleMaxLength = 20;
        let bookTitle = document.createElement("h5");
        bookTitle.classList.add("card-title");
        bookTitle.innerHTML = book.title.substring(0,titleMaxLength) + "...";
        cardBody.appendChild(bookTitle);

        let bookAuthor = document.createElement("h5");
        bookAuthor.classList.add("card-title");
        bookAuthor.innerHTML = book.author;
        cardBody.appendChild(bookAuthor);
        
        const genreMaxLength = 20;
        let bookGenre = document.createElement("h5");
        bookGenre.classList.add("card-title");
        bookGenre.innerHTML = `Genre: ${book.genre.substring(0,genreMaxLength)}...`;
        cardBody.appendChild(bookGenre);

        const descriptionMaxLength = 200;
        let bookDescription = document.createElement("p");
        bookDescription.classList.add("card-text");
        bookDescription.innerHTML = book.description.substring(0,descriptionMaxLength) + "...";
        cardBody.appendChild(bookDescription);

        let bookPrice = document.createElement("p");
        bookPrice.classList.add("card-text");
        bookPrice.innerHTML = `Price: ${book.price}`;
        cardBody.appendChild(bookPrice);

        let cardBtn = document.createElement("button");
        cardBtn.classList.add("btn");
        cardBtn.classList.add("btn-primary");

        if(storageService.existingStorage(book.id,"cartItems")){
            cardBtn.innerHTML = "Remove From Cart";
            cardBtn.onclick = function(event){removeFromCart(event,book.id);};
        }else{
            cardBtn.innerHTML = "Add To Cart";
            cardBtn.onclick = function(event){addToCart(event,book.id);};
        }
        cardBody.appendChild(cardBtn);
}

  function addToCart(event,bookId){
    storageService.addToLocalStorage(bookId, "cartItems");
    event.target.innerHTML = "Remove from Cart";
    event.target.onclick = function (event){removeFromCart(event,bookId);};
}

function removeFromCart(event,bookId){
    storageService.removeFromLocalStorage(bookId, "cartItems");
    event.target.innerHTML = "Add To Cart";
    event.target.onclick = function(event){addToCart(event,bookId);};
}