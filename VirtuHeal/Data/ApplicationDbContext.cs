using Microsoft.EntityFrameworkCore;
using VirtuHeal.Models;

namespace VirtuHeal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<VirtuHeal.Models.User>? Users { get; set; }

    }
}
