using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor_2_1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Razor_2_1.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public String Message { get; set; }

        public void OnGet(int BookId)
        {
            Book = _db.Books.Find(BookId);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var _Book = _db.Books.Find(Book.Id);
                _Book.Name = Book.Name;
                _Book.ISBN = Book.ISBN;
                _Book.Author = Book.Author;

                await _db.SaveChangesAsync();

                Message = "Book has been updated successfully!.";
                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}