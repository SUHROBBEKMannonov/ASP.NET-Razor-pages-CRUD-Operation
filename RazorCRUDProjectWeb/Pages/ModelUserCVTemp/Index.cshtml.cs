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
    public class IndexModel : PageModel
    {
        private readonly RazorCRUDProjectWeb.Data.ApplicationDbContext _context;

        public IndexModel(RazorCRUDProjectWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ModelUsers> ModelUsers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UsersInfoTable != null)
            {
                ModelUsers = await _context.UsersInfoTable.ToListAsync();
            }
        }
    }
}
