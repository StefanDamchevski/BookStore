using BookStore.Dto;

namespace BookStore.Services.Interfaces
{
    public interface IOrdersService
    {
        string Create(CreateOrderDto order);
        ViewOrderDto GetOrder(string email, string orderCode);
    }
}
