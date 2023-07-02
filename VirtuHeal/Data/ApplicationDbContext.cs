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

        public DbSet<User>? User { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Psychiatrist>? Psychiatrists { get; set; }
        public DbSet<StudentQuestions>? StudentQuestions { get; set; }
        public DbSet<PsychiatristpQuestions>? PsychiatristpQuestions { get; set; }

    }
}
