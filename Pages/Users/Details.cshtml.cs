using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public DetailsModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public accUser user { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.accUser.FirstOrDefaultAsync(m => m.idUser == id);

            if (user == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
