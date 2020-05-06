﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Zones
{
    public class CreateModel : PageModel
    {
        private readonly CronosegAccess.Data.CronosegAccessContext _context;

        public CreateModel(CronosegAccess.Data.CronosegAccessContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Zone Zone { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Zone.Add(Zone);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
