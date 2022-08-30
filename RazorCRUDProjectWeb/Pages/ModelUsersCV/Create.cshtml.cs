using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUDProjectWeb.Data;
using RazorCRUDProjectWeb.Model;

namespace RazorCRUDProjectWeb.Pages.ModelUsersCV
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ModelUsers modelUsers { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;   
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(ModelUsers modelUsers)
        {
            if (modelUsers.FirstName == modelUsers.LastName)
            {
                ModelState.AddModelError("modelUsers.LastName", "The Last Name cannot exactly match the First Name");
            }

            if (ModelState.IsValid) { 
            await _db.UsersInfoTable.AddAsync(modelUsers);   
            await _db.SaveChangesAsync();
                TempData["success"] = "User is created successfully!!!";
            return RedirectToPage("ListOfUsers");
            }
            return Page();

        }
    }
}
