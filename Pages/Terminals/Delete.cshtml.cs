using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Terminals
{
    public class DeleteModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public DeleteModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Terminal Terminal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Terminal = await _context.Terminal.FirstOrDefaultAsync(m => m.IdTerminal == id);

            if (Terminal == null)
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

            Terminal = await _context.Terminal.FindAsync(id);

            if (Terminal != null)
            {
                _context.Terminal.Remove(Terminal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
