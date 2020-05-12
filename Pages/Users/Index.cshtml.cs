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

namespace CronosegAccess.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public IndexModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public UserIndexData UserData { get; set; }
        public int UserID { get; set; }
        public int ZoneID { get; set; }


        public async Task OnGetAsync(int? id, int? ZoneID)
        {
            UserData = new UserIndexData();
            UserData.Users = await _context.accUser
                .Include(i => i.UserZones)
                    .ThenInclude(i => i.zone)
                        //.ThenInclude(i => i.Terminals)
                .AsNoTracking()
                .OrderBy(i => i.LastName)
                .ToListAsync();

            if (id != null)
            {
                UserID = id.Value;
                accUser user = UserData.Users
                    .Where(i => i.idUser == id.Value).Single();
                UserData.Zones = user.UserZones.Select(s => s.zone);
            }

            //if (ZoneID != null)
            //{
            //    ZoneID = ZoneID.Value;
            //    var selectedZone = UserData.Zones
            //        .Where(x => x.IdZone == ZoneID).Single();
            //    UserData.Terminals = selectedZone.Terminals;

               // User = await _context.User.ToListAsync();
           // }
        }
    }
}
