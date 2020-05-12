using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Users
{
    public class EditModel : UserZonesPageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public EditModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public accUser user { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            user = await _context.accUser
    .Include(i => i.UserZones).ThenInclude(i => i.zone)
    .AsNoTracking()
    .FirstOrDefaultAsync(m => m.idUser == id);
 //           User = await _context.User.FirstOrDefaultAsync(m => m.idUser == id);

            if (User == null)
            {
                return NotFound();
            }
            PopulateAssignedZoneData(_context, user);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedZones)
        {
            if (id == null)
            {
                return NotFound();
            }

            var UserToUpdate = await _context.accUser
                .Include(i => i.UserZones)
                    .ThenInclude(i => i.zone)
                .FirstOrDefaultAsync(s => s.idUser == id);

            if (UserToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<accUser>(
                UserToUpdate,
                "User",
                i => i.FirstName,
                i => i.LastName,
                i => i.dateIni,
                i => i.dateEnd,
                i => i.UserZones,
                i => i.Uid
                ))
            {
                UpdateUserZones(_context, selectedZones, UserToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateUserZones(_context, selectedZones, UserToUpdate);
            PopulateAssignedZoneData(_context, UserToUpdate);
            return Page();
        }


    }
}
