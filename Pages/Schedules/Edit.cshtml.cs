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

namespace CronosegAccess.Pages.Schedules
{
    public class EditModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public EditModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public accSchedule Schedule;

        public accSchedule GetSchedule()
        {
            return Schedule;
        }

        public void SetSchedule(accSchedule value)
        {
            Schedule = value;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SetSchedule(await _context.accSchedule.FirstOrDefaultAsync(m => m.IdSchedule == id));

            if (GetSchedule() == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GetSchedule()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(GetSchedule().IdSchedule))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScheduleExists(int id)
        {
            return _context.accSchedule.Any(e => e.IdSchedule == id);
        }
    }
}
