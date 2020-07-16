using BookStore.Data;
using BookStore.Dto;
using Microsoft.OpenApi.Extensions;
using System.Linq;

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
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Name = order.Name,
                Email = order.Email,
                Address = order.Address,
                OrderCode = order.OrderCode,
                Phone = order.Phone,
                FullPrice = order.FullPrice,
                Status = order.Status.GetDisplayName(),
                Books = order.BookOrders.Select(x => x.Book.ToBooksDto()).ToList(),
            };
        }
    }
}
