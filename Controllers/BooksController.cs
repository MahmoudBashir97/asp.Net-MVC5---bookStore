using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _Books.ViewModels;
using _Books.Models;
using System.Data.Entity;

namespace _Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public BooksController() {
            _dbContext = new ApplicationDBContext();
        }
        // GET: Books
        public ActionResult Index()
        {
            var books = _dbContext.Books.Include(mbox=>mbox.category).ToList();
            return View(books);
        }

        public ActionResult Details(int? id) {

            if (id == null) {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var book = _dbContext.Books.Include(mbox=>mbox.category).SingleOrDefault(m=>m.Id == id);
            if (book == null) {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Create()
        {
            var viewModel = new BookFromViewModel {
                categories = _dbContext.Categories.Where(m=>m.isActive).ToList()
                //categories = _dbContext.Categories.ToList()
            };

            return View("BookForm",viewModel);
        }

        public ActionResult Edit(int id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var book = _dbContext.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var viewModel = new BookFromViewModel { 
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Description = book.Description,
                categories = _dbContext.Categories.Where(m=>m.isActive).ToList()
            };

            return View("BookForm",viewModel);
        }

      [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookFromViewModel model) {

            if (!ModelState.IsValid)
            {
                model.categories = _dbContext.Categories.Where(m => m.isActive).ToList();
                return View("BookForm",model);
            }

            if (model.Id == 0)
            {
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    CategoryId = model.CategoryId,
                    Description = model.Description
                };

                _dbContext.Books.Add(book);
            }
            else {
                var book = _dbContext.Books.Find(model.Id);
                if (book == null) {
                    return HttpNotFound();
                    
                }
                book.Title = model.Title;
                book.Author = model.Author;
                book.CategoryId = model.CategoryId;
                book.Description = model.Description;
            }
                _dbContext.SaveChanges();

            TempData["Message"] = "Saved Successfully";
                return RedirectToAction("Index");
            

        }
    }
}