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
        public IList<Book> Book { get; set; } = default!;
        public BookData BookD { get; set; } = new BookData();
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();
            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();
            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                    .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}