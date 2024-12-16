using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Claudia_Lab2.Models;

namespace Pop_Claudia_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Pop_Claudia_Lab2.Data.Pop_Claudia_Lab2Context _context;

        public IndexModel(Pop_Claudia_Lab2.Data.Pop_Claudia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
