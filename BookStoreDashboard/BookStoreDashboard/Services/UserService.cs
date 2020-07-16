using BookStoreDashboard.Helpers;
using BookStoreDashboard.ModelsDto;
using BookStoreDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IdentityResult> CreateAsync(InputRegisterModel model)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<UserDtoModel> GetById(string userId)
        {
            IdentityUser user = await userManager.FindByIdAsync(userId);
            return user.ToUserDto();
        }

        public async Task<IdentityResult> UpdateAsync(UserDtoModel model)
        {
            IdentityUser user = await userManager.FindByIdAsync(model.UserId);

            if(user != null)
            {
                user.UserName = model.UserName;
                user.Email = model.Email;
            }

            IdentityResult result = await userManager.UpdateAsync(user);
            return result;
        }
    }
}
