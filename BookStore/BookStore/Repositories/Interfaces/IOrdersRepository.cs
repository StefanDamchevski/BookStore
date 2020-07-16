using BookStore.Data;
using System.Collections.Generic;

namespace BookStore.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        void Create(Order newOrder);
        Order GetOrder(string email, string orderCode);
        List<Order> GetAll();
        Order GetById(int id);
        void Update(Order dbOrder);
    }
}
