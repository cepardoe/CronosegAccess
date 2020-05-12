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
    public class IndexModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public IndexModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public IList<accTerminal> Terminal { get;set; }

        public async Task OnGetAsync()
        {
            Terminal = await _context.accTerminal
    .Include(c => c.Zone)
    .AsNoTracking()
    .ToListAsync();
        }
    }
}
