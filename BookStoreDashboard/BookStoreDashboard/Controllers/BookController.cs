using BookStoreDashboard.ModelsDto;
using BookStoreDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreDashboard.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Create()
        {
            BookDto model = new BookDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDto model)
        {
            if (ModelState.IsValid)
            {
                Response response = await bookService.Create(model);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageBooks");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, response.ErrorMessage);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ManageBooks()
        {
            List<BookDto> models = await bookService.GetAll();
            return View(models);
        }

        public async Task<IActionResult> Details(int bookId)
        {
            BookDto model = await bookService.GetById(bookId);
            return View(model);
        }

        public async Task<IActionResult> Edit(int bookId)
        {
            BookDto model = await bookService.GetById(bookId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookDto model)
        {
            if (ModelState.IsValid)
            {
                Response response = await bookService.Update(model);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageBooks");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, response.ErrorMessage);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int bookId)
        {
            await bookService.Delete(bookId);
            return RedirectToAction("ManageBooks");
        }
    }
}