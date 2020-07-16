using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreDashboard.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Actions()
        {
            return View();
        }
    }
}
