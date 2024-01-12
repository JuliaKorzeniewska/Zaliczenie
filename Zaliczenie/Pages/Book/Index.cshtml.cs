using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zaliczenie.Data;
using Zaliczenie.Model;

namespace Zaliczenie.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly Zaliczenie.Data.ZaliczenieContext _context;

        public IndexModel(Zaliczenie.Data.ZaliczenieContext context)
        {
            _context = context;
        }

        public IList<Kolekcje> Kolekcje { get;set; } = default!;

        public async Task OnGetAsync(string SearchString)
        { 
            var books = from b in _context.Kolekcje
                select b;
            if(!String.IsNullOrEmpty(SearchString))
            {
                books = _context.Kolekcje.Where(s => s.Title!.Contains(SearchString));
            }

                Kolekcje = await books.ToListAsync();
            
        }
    }
}
