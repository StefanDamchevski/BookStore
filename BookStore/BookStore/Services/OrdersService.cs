using BookStore.Data;
using BookStore.Dto;
using BookStore.Helpers;
using BookStore.Repositories.Interfaces;
using BookStore.Services.Interfaces;
using Microsoft.OpenApi.Extensions;
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
                Status = StatusEnum.Pending,
            };

            ordersRepository.Create(newOrder);

            return newOrder.OrderCode;
        }

        public List<OrderDto> GetAll()
        {
            return ordersRepository.GetAll().Select(x => x.ToOrderDto()).ToList();
        }

        public OrderDto GetById(int id)
        {
           return ordersRepository.GetById(id).ToOrderDto();
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
                Status = order.Status.GetDisplayName(),
            };

            return viewOrder;
        }

        public void UpdateStatus(OrderDto order)
        {
            Order dbOrder = ordersRepository.GetById(order.Id);

            StatusEnum.TryParse(order.Status, out StatusEnum result);

            if (dbOrder != null)
            {
                dbOrder.Status = result;
            }

            ordersRepository.Update(dbOrder);
        }
    }
}
