using CoreRazorWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreRazorWebApp.Pages.BookList
{
    public class IndexModel : PageModel
    {
        ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext context)
        {
            _db = context;    
        }

       public IEnumerable<Book> Books { get; set; }   
        public async Task OnGet()
        {
           Books= await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var BookFromDb=await _db.Book.FindAsync(id);
           if(BookFromDb!=null)
            {
                _db.Remove(BookFromDb);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
