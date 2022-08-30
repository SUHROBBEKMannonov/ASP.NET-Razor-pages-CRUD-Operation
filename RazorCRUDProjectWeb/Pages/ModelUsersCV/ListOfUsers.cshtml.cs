using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUDProjectWeb.Data;
using RazorCRUDProjectWeb.Model;

namespace RazorCRUDProjectWeb.Pages.ModelUsersCV
{
    public class ListOfUsersModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<ModelUsers> DataUsers { get; set; }

        public ListOfUsersModel(ApplicationDbContext db)
        {
            _db = db;
           
        }

        public void OnGet()
        {
            DataUsers = _db.UsersInfoTable.ToList();
        }
    }
}
