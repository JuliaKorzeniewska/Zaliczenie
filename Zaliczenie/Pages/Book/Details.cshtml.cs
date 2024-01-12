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
    public class DetailsModel : PageModel
    {
        private readonly Zaliczenie.Data.ZaliczenieContext _context;

        public DetailsModel(Zaliczenie.Data.ZaliczenieContext context)
        {
            _context = context;
        }

      public Kolekcje Kolekcje { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Kolekcje == null)
            {
                return NotFound();
            }

            var kolekcje = await _context.Kolekcje.FirstOrDefaultAsync(m => m.ID == id);
            if (kolekcje == null)
            {
                return NotFound();
            }
            else 
            {
                Kolekcje = kolekcje;
            }
            return Page();
        }
    }
}
