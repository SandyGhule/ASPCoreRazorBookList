using CoreRazorWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CoreRazorWebApp.Pages.BookList
{
    public class EditModel : PageModel
    {
        ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book book { get; set; }
        public async void OnGet(int id)
        {
            book=await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(id);
                BookFromDb.Id = book.Id;
                BookFromDb.Name = book.Name;
                BookFromDb.Autor = book.Autor;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
