using BookStoreDashboard.ModelsDto;
using BookStoreDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreDashboard.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public async Task<IActionResult> ManageOrders()
        {
            List<OrderDto> models = await orderService.GetAll();
            return View(models);
        }
        public async Task<IActionResult> SetStatus(int orderId, string status)
        {
            Response response = await orderService.UpdateStatus(orderId, status);
            return RedirectToAction("ManageOrders");
        }
    }
}