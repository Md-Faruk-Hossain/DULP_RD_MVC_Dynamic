using DUPL_RD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DUPL_RD.Controllers
{
    public class BooksController : Controller
    {
        BookDbContext db= new BookDbContext();
        public ActionResult Index()
        {
            var result = db.Books.ToList();
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var books = new Book()
                {
                   
                    Date = book.Date,
                    BookName = book.BookName,
                    Author = book.Author,
                    Quentity = book.Quentity
                };
                db.Books.Add(books);
                db.SaveChanges();
                TempData["error"] = "Record Save";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty field Can't Submit";
                return RedirectToAction("Index");
            }

        }
        public ActionResult Edit(int id)
        {

            var books = db.Books.SingleOrDefault(e => e.Id == id);
            var result = new Book()
            {
                Id = books.Id,
                Date = books.Date,
                BookName = books.BookName,
                Author = books.Author,
                Quentity = books.Quentity
            };
            return View(result);


        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var books = new Book()
                {
                    Id= book.Id,
                    Date = book.Date,
                    BookName = book.BookName,
                    Author = book.Author,
                    Quentity = book.Quentity

                };
              
                db.Entry(books).State=EntityState.Modified;
                db.SaveChanges();
                
                
            }
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int id)
        {
            var book = db.Books.First(e => e.Id == id);
            db.Entry(book).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}