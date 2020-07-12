using BookStore.Data;
using BookStore.Dto;
using BookStore.Helpers;
using BookStore.Repositories.Interfaces;
using BookStore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        public void Create(BooksDto booksDto)
        {
            booksRepository.Create(booksDto.ToBook());
        }

        public void Delete(int id)
        {
            Book book = booksRepository.GetById(id);
            if(book != null)
            {
                booksRepository.Delete(book);
            }
        }

        public List<BooksDto> GetAll()
        {
           return booksRepository.GetAll().Select(x => x.ToBooksDto()).ToList();
        }

        public List<BooksDto> GetByAuthor(string author)
        {
            return booksRepository.GetByAuthor(author).Select(x => x.ToBooksDto()).ToList();
        }

        public BooksDto GetById(int id)
        {
            return booksRepository.GetById(id).ToBooksDto();
        }

        public List<BooksDto> GetByIds(List<int> bookIds)
        {
            return booksRepository.GetByIds(bookIds).Select(x => x.ToBooksDto()).ToList();
        }

        public void Update(BooksDto booksDto)
        {
            Book dbBook = booksRepository.GetById(booksDto.Id);
            if(dbBook != null)
            {
                dbBook.Title = booksDto.Title;
                dbBook.Author = booksDto.Author;
                dbBook.Description = booksDto.Description;
                dbBook.Genre = booksDto.Genre;
                dbBook.Quantity = booksDto.Quantity;
                dbBook.Price = booksDto.Price;

                booksRepository.Update(dbBook);
            }
        }
    }
}
