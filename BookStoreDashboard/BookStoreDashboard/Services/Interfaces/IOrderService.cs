using BookStoreDashboard.ModelsDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAll();
        Task<Response> UpdateStatus(int orderId, string status);
    }
}
