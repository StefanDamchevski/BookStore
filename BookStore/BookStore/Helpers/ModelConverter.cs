using BookStore.Data;
using BookStore.Dto;

namespace BookStore.Helpers
{
    public static class ModelConverter
    {
        public static BooksDto ToBooksDto(this Book book)
        {
            return new BooksDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Genre = book.Genre,
                Quantity = book.Quantity,
                Price = book.Price,
            };
        }
        public static Book ToBook(this BooksDto book)
        {
            return new Book
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Genre = book.Genre,
                Quantity = book.Quantity,
                Price = book.Price,
            };
        }
    }
}
