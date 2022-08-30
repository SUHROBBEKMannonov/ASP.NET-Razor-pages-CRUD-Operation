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
    public class DetailsModel : PageModel
    {
        private readonly RazorCRUDProjectWeb.Data.ApplicationDbContext _context;

        public DetailsModel(RazorCRUDProjectWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
