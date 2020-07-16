using BookStoreDashboard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int orderId);
        Task<bool> Update(Order order);
    }
}
