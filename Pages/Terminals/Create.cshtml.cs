using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Terminals
{
    public class CreateModel : ZoneNamePageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public CreateModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateZonesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public accTerminal Terminal { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var emptyTerminal = new accTerminal();

            if (await TryUpdateModelAsync<accTerminal>(
                 emptyTerminal,
                 "terminal",   // Prefix for form value.
                 s => s.IdTerminal, s => s.idZone, s => s.Name))
            {
                _context.accTerminal.Add(emptyTerminal);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateZonesDropDownList(_context, emptyTerminal.idZone);
            return Page();
        }
    }
}
