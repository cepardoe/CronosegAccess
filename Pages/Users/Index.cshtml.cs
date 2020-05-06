using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CronosegAccess.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public IndexModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> zoneQuery = from u in _context.User
                                            orderby u.Zone
                                            select u.Zone;
            var users = from u in _context.User
                         select u;
            if (!string.IsNullOrEmpty(SearchString))
            {
                users = users.Where(s => s.FirstName.Contains(SearchString) ||
                                         s.LastName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(UserZone))
            {
                users = users.Where(x => x.Zone == UserZone);
            }
            Zone = new SelectList(await zoneQuery.Distinct().ToListAsync());
            User = await users.ToListAsync();


              User = await _context.User.Include(z=>z.Zone).AsNoTracking().ToListAsync();
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Zone { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserZone { get; set; }

        public SelectList Schedule { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserSchedule { get; set; }
    }
}
