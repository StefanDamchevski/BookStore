using BookStoreDashboard.ModelsDto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(InputRegisterModel model);
        Task<UserDtoModel> GetById(string userId);
        Task<IdentityResult> UpdateAsync(UserDtoModel model);
    }
}
