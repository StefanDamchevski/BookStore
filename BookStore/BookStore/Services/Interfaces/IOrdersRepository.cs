using BookStore.Data;

namespace BookStore.Services.Interfaces
{
    public interface IOrdersRepository
    {
        void Create(Order newOrder);
        Order GetOrder(string email, string orderCode);
    }
}
