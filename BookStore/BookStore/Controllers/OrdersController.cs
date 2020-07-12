using BookStore.Dto;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }
        [HttpPost]
        public IActionResult Create(CreateOrderDto order)
        {
            string orderCode = ordersService.Create(order);
            return Ok(new {orderCode = orderCode });
        }
        [HttpGet]
        [Route("details")]
        public IActionResult ViewOrder(string email, string orderCode)
        {
            ViewOrderDto orderDto = ordersService.GetOrder(email, orderCode); 
            return Ok(orderDto);
        }
    }
}
