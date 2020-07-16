using BookStore.Dto;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        /// <summary>
        /// Creates an order and returns a string
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Create(CreateOrderDto order)
        {
            string orderCode = ordersService.Create(order);
            return Ok(new {orderCode = orderCode });
        }
        /// <summary>
        /// Returns order with given email and orderCode
        /// </summary>
        /// <param name="email"></param>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("details")]
        public ActionResult<ViewOrderDto> ViewOrder(string email, string orderCode)
        {
            ViewOrderDto orderDto = ordersService.GetOrder(email, orderCode); 
            return Ok(orderDto);
        }
        /// <summary>
        /// Returns all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            List<OrderDto> orderDto = ordersService.GetAll();
            return Ok(orderDto);
        }
        /// <summary>
        /// Returns order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<OrderDto> GetById(int id)
        {
            OrderDto orderDto = ordersService.GetById(id);
            return Ok(orderDto);
        }
        /// <summary>
        /// Updates order status
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateStatus(OrderDto order)
        {
            ordersService.UpdateStatus(order);
            return Ok();
        }
    }
}