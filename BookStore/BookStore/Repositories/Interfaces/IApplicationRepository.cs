using System.Threading.Tasks;
using BookStore.Data;

namespace BookStore.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task<Application> GetApplicationAsync(string apiKey);
    }
}
