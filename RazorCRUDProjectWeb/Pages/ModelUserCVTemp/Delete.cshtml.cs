using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCRUDProjectWeb.Data;
using RazorCRUDProjectWeb.Model;

namespace RazorCRUDProjectWeb.Pages.ModelUserCVTemp
{
    public class DeleteModel : PageModel
    {
        private readonly RazorCRUDProjectWeb.Data.ApplicationDbContext _context;

        public DeleteModel(RazorCRUDProjectWeb.Data.ApplicationDbContext context)
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

            var modelusers = await _context.UsersInfoTable.FirstOrDefaultAsync(m => m.Id == id);

            if (modelusers == null)
            {
                return NotFound();
            }
            else 
            {
                ModelUsers = modelusers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UsersInfoTable == null)
            {
                return NotFound();
            }
            var modelusers = await _context.UsersInfoTable.FindAsync(id);

            if (modelusers != null)
            {
                ModelUsers = modelusers;
                _context.UsersInfoTable.Remove(ModelUsers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
