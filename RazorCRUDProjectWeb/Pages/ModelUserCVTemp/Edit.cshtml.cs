using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorCRUDProjectWeb.Data;
using RazorCRUDProjectWeb.Model;

namespace RazorCRUDProjectWeb.Pages.ModelUserCVTemp
{
    public class EditModel : PageModel
    {
        private readonly RazorCRUDProjectWeb.Data.ApplicationDbContext _context;

        public EditModel(RazorCRUDProjectWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ModelUsers ModelUsers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UsersInfoTable == null)
            {
                return NotFound();
            }

            var modelusers =  await _context.UsersInfoTable.FirstOrDefaultAsync(m => m.Id == id);
            if (modelusers == null)
            {
                return NotFound();
            }
            ModelUsers = modelusers;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ModelUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelUsersExists(ModelUsers.Id))
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

        private bool ModelUsersExists(int id)
        {
          return (_context.UsersInfoTable?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
