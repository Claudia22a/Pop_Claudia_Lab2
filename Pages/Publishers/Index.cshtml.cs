using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Claudia_Lab2.Data;
using Pop_Claudia_Lab2.Models;

namespace Pop_Claudia_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Pop_Claudia_Lab2.Data.Pop_Claudia_Lab2Context _context;

        public IndexModel(Pop_Claudia_Lab2.Data.Pop_Claudia_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; private set; } = new List<Book>();
        public IList<Publisher> Publisher { get; set; } = new List<Publisher>();

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Publisher)
                .ToListAsync();
            Publisher = await _context.Publisher
              .Include(p => p.Books)
              .ToListAsync();
        }
    }
}
