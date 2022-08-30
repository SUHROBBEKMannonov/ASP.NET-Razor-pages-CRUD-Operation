using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorCRUDProjectWeb.Data;
using RazorCRUDProjectWeb.Model;

namespace RazorCRUDProjectWeb.Pages.ModelUserCVTemp
{
    public class CreateModel : PageModel
    {
        private readonly RazorCRUDProjectWeb.Data.ApplicationDbContext _context;

        public CreateModel(RazorCRUDProjectWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ModelUsers ModelUsers { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UsersInfoTable == null || ModelUsers == null)
            {
                return Page();
            }

            _context.UsersInfoTable.Add(ModelUsers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
