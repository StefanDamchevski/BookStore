using BookStore.Dto;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }
        /// <summary>
        /// Returns list of all books 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<BooksDto>> Get()
        {
            return Ok(booksService.GetAll());
        }
        /// <summary>
        /// Returns a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<BooksDto> Get(int id)
        {
            return Ok(booksService.GetById(id));
        }
        /// <summary>
        /// Returns list of books by author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("author")]
        public ActionResult<List<BooksDto>> Get(string author)
        {
            return Ok(booksService.GetByAuthor(author));
        }
        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="booksDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Create(BooksDto booksDto)
        {
            booksService.Create(booksDto);
            return Ok();
        }
        /// <summary>
        /// Deletes a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            booksService.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Updates book
        /// </summary>
        /// <param name="booksDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public IActionResult Update(BooksDto booksDto)
        {
            booksService.Update(booksDto);
            return Ok();
        }
    }
}