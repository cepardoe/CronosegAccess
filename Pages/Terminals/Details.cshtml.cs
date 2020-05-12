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
    public class DetailsModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public DetailsModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public accTerminal Terminal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Terminal = await _context.accTerminal
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdTerminal == id);

            if (Terminal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
