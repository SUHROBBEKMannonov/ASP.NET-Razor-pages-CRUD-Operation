using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUDProjectWeb.Data;
using RazorCRUDProjectWeb.Model;

namespace RazorCRUDProjectWeb.Pages.ModelUsersCV
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ModelUsers modelUsers { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;   
        }
        public void OnGet(int id)
        {
            modelUsers = _db.UsersInfoTable.Find(id);
        }
        public async Task<IActionResult> OnPost(ModelUsers modelUsers)
        {
            if (modelUsers.FirstName == modelUsers.LastName)
            {
                ModelState.AddModelError("modelUsers.LastName", "The Last Name cannot exactly match the First Name");
            }

            if (ModelState.IsValid) { 
             _db.UsersInfoTable.Update(modelUsers);   
            await _db.SaveChangesAsync();
                TempData["success"] = "User is updated successfully!!!";
                return RedirectToPage("ListOfUsers");
            }
            return Page();

        }
    }
}
