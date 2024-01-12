using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zaliczenie.Data;
using Zaliczenie.Model;

namespace Zaliczenie.Pages.Book
{
    public class EditModel : PageModel
    {
        private readonly Zaliczenie.Data.ZaliczenieContext _context;

        public EditModel(Zaliczenie.Data.ZaliczenieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kolekcje Kolekcje { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Kolekcje == null)
            {
                return NotFound();
            }

            var kolekcje =  await _context.Kolekcje.FirstOrDefaultAsync(m => m.ID == id);
            if (kolekcje == null)
            {
                return NotFound();
            }
            Kolekcje = kolekcje;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kolekcje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KolekcjeExists(Kolekcje.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KolekcjeExists(int id)
        {
          return (_context.Kolekcje?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
