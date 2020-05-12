using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Users
{
    public class CreateModel : UserZonesPageModel
    {
        private readonly CronosegAccessContext _context;

        public CreateModel(CronosegAccessContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public accUser user { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.accUser.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
