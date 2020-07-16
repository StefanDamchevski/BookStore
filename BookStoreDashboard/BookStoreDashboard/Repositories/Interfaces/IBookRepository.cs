using BookStoreDashboard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<bool> Update(Book book);
        Task<bool> Create(Book book);
        Task Delete(int id);
    }
}
