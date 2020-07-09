using BookStore.Dto;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(booksService.GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(booksService.GetById(id));
        }
        [HttpGet]
        [Route("author")]
        public IActionResult Get(string author)
        {
            return Ok(booksService.GetByAuthor(author));
        }
        [HttpPost]
        public IActionResult Create(BooksDto booksDto)
        {
            booksService.Create(booksDto);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            booksService.Delete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(BooksDto booksDto)
        {
            booksService.Update(booksDto);
            return Ok();
        }
    }
}