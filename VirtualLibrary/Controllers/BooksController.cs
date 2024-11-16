using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Data;
using VirtualLibrary.Models;
using VirtualLibrary.Models.Entities;

namespace VirtualLibrary.Controllers
{
    public class BooksController : Controller
    {

        //INYECCCION DE DEPENDENCIAS
        private readonly ApplicationDbContext dbContext;

        public BooksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                return View(viewModel);
            }

            var book = new Book
            {
                Title = viewModel.Title,
                Author = viewModel.Author,
                PublishedYear = viewModel.PublishedYear,
                Genre = viewModel.Genre,
                AvailableCopies = viewModel.AvailableCopies,
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var books = await dbContext.Books.ToListAsync();
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await dbContext.Books.FindAsync(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var book = await dbContext.Books.FindAsync(viewModel.Id);

            if (book is not null)
            {
                book.Title = viewModel.Title;
                book.Author = viewModel.Author;
                book.PublishedYear = viewModel.PublishedYear;
                book.Genre = viewModel.Genre;
                book.AvailableCopies = viewModel.AvailableCopies;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await dbContext.Books.FindAsync(id);

            if (book != null) {

                dbContext.Books.Remove(book);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}
