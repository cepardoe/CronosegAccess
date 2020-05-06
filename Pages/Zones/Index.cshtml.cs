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
    public class IndexModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public IndexModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public IList<Zone> Zone { get;set; }

        public async Task OnGetAsync()
        {
            Zone = await _context.Zone.ToListAsync();
        }
    }
}
