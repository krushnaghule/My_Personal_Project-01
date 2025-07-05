using Microsoft.EntityFrameworkCore;
using My_Personal_Project.Models;

namespace My_Personal_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LoginModel> Login { get; set; }
    }
}
