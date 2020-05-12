using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Schedules
{
    public class DetailsModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public DetailsModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public accSchedule Schedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Schedule = await _context.accSchedule.FirstOrDefaultAsync(m => m.IdSchedule == id);

            if (Schedule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
