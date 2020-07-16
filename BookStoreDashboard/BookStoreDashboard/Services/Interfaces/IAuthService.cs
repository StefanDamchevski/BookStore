using BookStoreDashboard.ModelsDto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services.Interfaces
{
    public interface IAuthService
    {
        Task LogoutAsync();
        Task<SignInResult> LoginAsync(InputLoginModel model);
    }
}
