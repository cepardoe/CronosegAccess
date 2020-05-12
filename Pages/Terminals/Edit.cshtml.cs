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

namespace CronosegAccess.Pages.Terminals
{
    public class EditModel : ZoneNamePageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public EditModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public accTerminal Terminal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Terminal = await _context.accTerminal
                .Include(c=>c.Zone)
                .FirstOrDefaultAsync(m => m.IdTerminal == id);

            if (Terminal == null)
            {
                return NotFound();
            }

            PopulateZonesDropDownList(_context, Terminal.idZone);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var TerminaltoUpdate = await _context.accTerminal.FindAsync(id);

            if (await TryUpdateModelAsync<accTerminal>(
                 TerminaltoUpdate,
                 "terminal",   // Prefix for form value.
                 s => s.IdTerminal, s => s.idZone, s => s.Name))
            {
                _context.accTerminal.Update(TerminaltoUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerminalExists(Terminal.IdTerminal))
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

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateZonesDropDownList(_context, TerminaltoUpdate.idZone);
            return Page();
        }

        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(Terminal).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TerminalExists(Terminal.IdTerminal))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        private bool TerminalExists(int id)
        {
            return _context.accTerminal.Any(e => e.IdTerminal == id);
        }
    }
}
