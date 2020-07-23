using BookStoreDashboard.ModelsDto;
using BookStoreDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreDashboard.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Register()
        {
            InputRegisterModel model = new InputRegisterModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(InputRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await userService.CreateAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Auth");
                }
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Details(string userId)
        {
            UserDtoModel model = await userService.GetById(userId);
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Edit(string userId)
        {
            UserDtoModel model = await userService.GetById(userId);
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(UserDtoModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await userService.UpdateAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Details", new {userId = model.UserId });
                }
            }
            return View(model);
        }
    }
}