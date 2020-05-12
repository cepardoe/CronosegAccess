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
    public class DetailsModel : PageModel
    {
        private readonly CronosegAccessContext _context;

        public DetailsModel(CronosegAccessContext context)
        {
            _context = context;
        }

        public accZone accZone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            accZone = await _context.accZone.FirstOrDefaultAsync(m => m.IdZone == id);

            if (accZone == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
