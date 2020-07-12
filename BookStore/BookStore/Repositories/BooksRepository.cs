using BookStore.Data;
using BookStore.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStroreDbContext context;

        public BooksRepository(BookStroreDbContext context)
        {
            this.context = context;
        }

        public void Create(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void Delete(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public List<Book> GetByAuthor(string author)
        {
            return context.Books.Where(x => x.Author == author).ToList();
        }
        public Book GetById(int id)
        {
            return context.Books.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetByIds(List<int> bookIds)
        {
            return context.Books.Where(x => bookIds.Contains(x.Id)).ToList();
        }

        public void Update(Book dbBook)
        {
            context.Books.Update(dbBook);
            context.SaveChanges();
        }
    }
}
