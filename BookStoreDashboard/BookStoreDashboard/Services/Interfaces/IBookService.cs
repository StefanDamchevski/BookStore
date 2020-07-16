using BookStoreDashboard.ModelsDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAll();
        Task<BookDto> GetById(int id);
        Task<Response> Update(BookDto model);
        Task<Response> Create(BookDto model);
        Task Delete(int bookId);
    }
}
