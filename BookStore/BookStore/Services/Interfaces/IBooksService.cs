using BookStore.Dto;
using System.Collections.Generic;

namespace BookStore.Services.Interfaces
{
    public interface IBooksService
    {
        List<BooksDto> GetAll();
        BooksDto GetById(int id);
        List<BooksDto> GetByAuthor(string author);
        void Create(BooksDto booksDto);
        void Delete(int id);
        void Update(BooksDto booksDto);
        List<BooksDto> GetByIds(List<int> bookIds);
    }
}
