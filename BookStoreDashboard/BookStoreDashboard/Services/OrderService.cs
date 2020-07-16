using BookStoreDashboard.Helpers;
using BookStoreDashboard.Models;
using BookStoreDashboard.ModelsDto;
using BookStoreDashboard.Repositories.Interfaces;
using BookStoreDashboard.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        
        public async Task<List<OrderDto>> GetAll()
        {
            List<Order> orders = await orderRepository.GetAll();
            return orders.Select(x => x.ToOrderDto()).ToList();
        }

        public async Task<Response> UpdateStatus(int orderId, string status)
        {
            Order order = await orderRepository.GetById(orderId);

            if (order != null)
            {
                order.Status = status;
            }

            bool isSuccessful = await orderRepository.Update(order);

            return IsSuccessful(isSuccessful);
        }

        private static Response IsSuccessful(bool isSuccessful)
        {
            Response response = new Response();

            if (isSuccessful)
            {
                response.IsSuccessful = true;
                return response;
            }
            else
            {
                response.IsSuccessful = false;
                response.ErrorMessage = "Something Went Wrong";
                return response;
            }
        }
    }
}
