using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUDProjectWeb.Data;
using RazorCRUDProjectWeb.Model;

namespace RazorCRUDProjectWeb.Pages.ModelUsersCV
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ModelUsers modelUsers { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;   
        }
        public void OnGet(int id)
        {
            modelUsers = _db.UsersInfoTable.Find(id);
        }
        public async Task<IActionResult> OnPost(ModelUsers modelUsers)
        {
           

            
                var categoryFromDb = _db.UsersInfoTable.Find(modelUsers.Id);
                if (categoryFromDb != null)
                {
                    _db.UsersInfoTable.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                    TempData["success"] = "User is deleted successfully!!!";
                    return RedirectToPage("ListOfUsers");
                }
                              
            
            return Page();

        }
    }
}
