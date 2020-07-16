using BookStoreDashboard.Helpers;
using BookStoreDashboard.Models;
using BookStoreDashboard.ModelsDto;
using BookStoreDashboard.Repositories.Interfaces;
using BookStoreDashboard.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDashboard.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<Response> Create(BookDto model)
        {
            Book book = new Book();
            book.Title = model.Title;
            book.Author = model.Author;
            book.Description = model.Description;
            book.Genre = model.Genre;
            book.Price = model.Price;
            book.Quantity = model.Quantity;

            bool isSuccessful = await bookRepository.Create(book);
            Response response = CheckIfFailed(isSuccessful);

            return response;
        }

        public async Task<List<BookDto>> GetAll()
        {
            List<Book> books = await bookRepository.GetAll();
            return books.Select(x => x.ToBookDto()).ToList();
        }

        public async Task<BookDto> GetById(int id)
        {
            Book book = await bookRepository.GetById(id);
            return book.ToBookDto();
        }

        public async Task<Response> Update(BookDto model)
        {
            Book book = await bookRepository.GetById(model.Id);

            if (book != null)
            {
                book.Title = model.Title;
                book.Author = model.Author;
                book.Description = model.Description;
                book.Genre = model.Genre;
                book.Price = model.Price;
                book.Quantity = model.Quantity;
            }

            bool isSuccessful = await bookRepository.Update(book);
            Response response = CheckIfFailed(isSuccessful);

            return response;
        }
        private static Response CheckIfFailed(bool isSuccessful)
        {
            Response response = new Response();
            if (isSuccessful)
            {
                response.IsSuccessful = true;
                return response;
            }
            else
            {
                response.IsSuccessful = false;
                response.ErrorMessage = "Something went wrong please try again later!!";
                return response;
            }
        }

        public async Task Delete(int bookId)
        {
           await bookRepository.Delete(bookId);
        }
    }
}
