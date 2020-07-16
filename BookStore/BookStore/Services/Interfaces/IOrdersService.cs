using BookStore.Dto;
using System.Collections.Generic;

namespace BookStore.Services.Interfaces
{
    public interface IOrdersService
    {
        string Create(CreateOrderDto order);
        ViewOrderDto GetOrder(string email, string orderCode);
        List<OrderDto> GetAll();
        OrderDto GetById(int id);
        void UpdateStatus(OrderDto order);
    }
}
