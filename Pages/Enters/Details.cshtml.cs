using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Enters
{
    public class DetailsModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public DetailsModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public accEnter accEnter { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            accEnter = await _context.accEnter
                .Include(a => a.mode)
                .Include(a => a.result)
                .Include(a => a.user).FirstOrDefaultAsync(m => m.idEnter == id);

            if (accEnter == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
