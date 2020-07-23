using BookStore.Data;
using BookStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly BookStroreDbContext context;

        public ApplicationRepository(BookStroreDbContext context)
        {
            this.context = context;
        }

        public async Task<Application> GetApplicationAsync(string apiKey)
        {
            return await context.Applications.FirstOrDefaultAsync(x => x.ApiKey.Equals(apiKey));
        }
    }
}
