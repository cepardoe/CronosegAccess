using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Zones
{
    public class EditModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public EditModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public accZone Zone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Zone = await _context.accZone.FirstOrDefaultAsync(m => m.IdZone == id);

            if (Zone == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Zone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(Zone.IdZone))
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

        private bool ZoneExists(int id)
        {
            return _context.accZone.Any(e => e.IdZone == id);
        }
    }
}
