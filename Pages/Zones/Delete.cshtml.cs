using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Zones
{
    public class DeleteModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public DeleteModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Zone Zone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Zone = await _context.Zone.FirstOrDefaultAsync(m => m.IdZone == id);

            if (Zone == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Zone = await _context.Zone.FindAsync(id);

            if (Zone != null)
            {
                _context.Zone.Remove(Zone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
