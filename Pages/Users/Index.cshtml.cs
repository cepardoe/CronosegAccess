using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;
using CronosegAccess.Models.ViewModel;
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

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Zones { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserZones { get; set; }

        public UserIndexData UserData { get; set; }
        public int UserID { get; set; }
        public int ZoneID { get; set; }


        public async Task OnGetAsync(int? id)
        {
            UserData = new UserIndexData();
            var users = _context.accUser
                .Include(i => i.UserZones)
                    .ThenInclude(i => i.zone)
                //.ThenInclude(i => i.Terminals)
                .AsNoTracking();
            if (!string.IsNullOrEmpty(SearchString))
            {
                users=users.Where(s => s.FirstName.Contains(SearchString) || s.LastName.Contains(SearchString) || s.Uid.Contains(SearchString) );
            }
            UserData.Users = await users
                .OrderBy(i => i.LastName)
                .ToListAsync();




            if (id != null)
            {
                UserID = id.Value;
                accUser user = UserData.Users
                    .Where(i => i.idUser == id.Value).Single();
                UserData.Zones = user.UserZones.Select(s => s.zone);
            }




        }
    }
}
