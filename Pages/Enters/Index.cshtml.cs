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
    public class IndexModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public IndexModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public IList<accEnter> accEnter { get;set; }

        public async Task OnGetAsync()
        {
            accEnter = await _context.accEnter
                .Include(a => a.mode)
                .Include(a => a.result)
                .Include(a => a.user).ToListAsync();
        }
    }
}
