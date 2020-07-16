using BookStoreDashboard.ModelsDto;
using BookStoreDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<SignInResult> LoginAsync(InputLoginModel model)
        {
            IdentityUser user = await userManager.FindByEmailAsync(model.Email);
            SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, false ,false);
            return result;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
