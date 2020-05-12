using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronosegAccess.Pages.Terminals
{
    public class ZoneNamePageModel: PageModel
    {
        public SelectList ZoneNameSL { get; set; }

        public void PopulateZonesDropDownList(CronosegAccess.Data.CronosegAccessContext _context,
            object selectedZone = null)
        {
            var zonesQuery = from d in _context.accZone
                                   orderby d.Name // Sort by name.
                                   select d;

            ZoneNameSL = new SelectList(zonesQuery.AsNoTracking(),
                        "IdZone", "Name", selectedZone);
        }
    }
}
