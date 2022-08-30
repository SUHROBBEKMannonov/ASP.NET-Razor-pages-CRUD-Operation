using Microsoft.EntityFrameworkCore;
using RazorCRUDProjectWeb.Model;

namespace RazorCRUDProjectWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
            public DbSet<ModelUsers> UsersInfoTable { get; set; }
    }
         
    }
