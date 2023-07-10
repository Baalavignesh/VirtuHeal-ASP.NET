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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users
            // Users - Student (One to One)
            modelBuilder.Entity<User>()
                .HasOne(c => c.Student)
                .WithOne(c=>c.User)
                .HasForeignKey<Student>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users - Psychiatrist (One to One)
            modelBuilder.Entity<User>()
                .HasOne(c => c.Psychiatrist)
                .WithOne(c => c.User)
                .HasForeignKey<Psychiatrist>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Student - College (One to Many)
            //modelBuilder.Entity<Student>()
            //    .HasMany(c => c.College)
            //    .WithOne(c => c.Student)
            //    .HasForeignKey<College>(c => c.college_id)
            //    .OnDelete(DeleteBehavior.Restrict);



            // Student - MyChats  (One to Many)
            modelBuilder.Entity<Student>()
                .HasMany(c => c.MyChats)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Psychiatrist - MyChats  (One to Many)
            modelBuilder.Entity<Psychiatrist>()
                .HasMany(c => c.MyChats)
                .WithOne(c => c.Psychiatrist)
                .HasForeignKey(c => c.PsychiatristId)
                .OnDelete(DeleteBehavior.Restrict);

            // MyChat - SingleChatMessage  (One to Many)
            modelBuilder.Entity<MyChats>()
                .HasMany(c => c.SingleChatMessages)
                .WithOne(c => c.MyChats)
                .HasForeignKey(c => c.ParentChatId)
                .OnDelete(DeleteBehavior.Restrict);

            // User - UserSession
            //modelBuilder.Entity<UserSession>()
            //    .HasOne(c => c.User)
            //    .WithOne()
            //    .HasForeignKey<UserSession>(c => c.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

        }



        public DbSet<User>? User { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Psychiatrist>? Psychiatrists { get; set; }
        public DbSet<StudentQuestions>? StudentQuestions { get; set; }
        public DbSet<PsychiatristpQuestions>? PsychiatristpQuestions { get; set; }
        public DbSet<College>? Colleges { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MyChats>? MyChats { get; set; }
        public DbSet<SingleChatMessage>? SingleChatMessage { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
    }
}
