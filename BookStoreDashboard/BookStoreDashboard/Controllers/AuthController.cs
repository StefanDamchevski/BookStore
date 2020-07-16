using BookStoreDashboard.Models;
using BookStoreDashboard.ModelsDto;
using BookStoreDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BookStoreDashboard.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Actions", "Dashboard");
            }
            else
            {
                InputLoginModel model = new InputLoginModel();
                return View(model);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(InputLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await authService.LoginAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Actions", "Dashboard");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction("Login");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
