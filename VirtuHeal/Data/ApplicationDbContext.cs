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
        public DbSet<College>? Colleges { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Student>()
        //        .HasOne(s => s.User)
        //        .WithMany()
        //        .HasForeignKey(s => s.user_id)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Psychiatrist>()
        //        .HasOne(s => s.User)
        //        .WithMany()
        //        .HasForeignKey(s => s.user_id)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}



    }
}
