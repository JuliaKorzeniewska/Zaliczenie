using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zaliczenie.Data;
using Zaliczenie.Model;

namespace Zaliczenie.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly Zaliczenie.Data.ZaliczenieContext _context;

        public CreateModel(Zaliczenie.Data.ZaliczenieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kolekcje Kolekcje { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Kolekcje == null || Kolekcje == null)
            {
                return Page();
            }

            _context.Kolekcje.Add(Kolekcje);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
