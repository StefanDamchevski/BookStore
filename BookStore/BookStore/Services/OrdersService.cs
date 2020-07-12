using BookStore.Data;
using BookStore.Dto;
using BookStore.Helpers;
using BookStore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IBooksService booksService;

        public OrdersService(IOrdersRepository ordersRepository, IBooksService booksService)
        {
            this.ordersRepository = ordersRepository;
            this.booksService = booksService;
        }
        public string Create(CreateOrderDto order)
        {
            List<BooksDto> books = booksService.GetByIds(order.BookIds);

            Order newOrder = new Order
            {
                Name = order.Name,
                Email = order.Email,
                Address = order.Address,
                Phone = order.Phone,
                BookOrders = order.BookIds.Select(x => new BookOrders
                {
                    BookId = x,
                }).ToList(),
                FullPrice = books.Sum(x => x.Price),
                OrderCode = RandomString.GenerateRandomString(6),
            };

            ordersRepository.Create(newOrder);

            return newOrder.OrderCode;
        }

        public ViewOrderDto GetOrder(string email, string orderCode)
        {
            Order order = ordersRepository.GetOrder(email, orderCode);

            ViewOrderDto viewOrder = new ViewOrderDto
            {
                Email = order.Email,
                OrderCode = order.OrderCode,
                FullPrice = order.FullPrice,
                Books = order.BookOrders
                .Select(x => x.Book.ToBooksDto())
                .ToList(),
            };

            return viewOrder;
        }
    }
}
