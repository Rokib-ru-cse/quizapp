using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var meta = modelBuilder.Entity<Question>().Metadata;
            var indexs = meta.GetIndexes().ToList();
            foreach (var i in indexs)
            {
                meta.RemoveIndex(i);
            }

            modelBuilder.Entity<Question>()
                       .HasOne(x => x.CreatedBy)
                       .WithOne()
                       .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Question>()
                       .HasOne(x => x.UpdatedBy)
                       .WithOne()
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quiz>()
                       .HasOne(x => x.CreatedBy)
                       .WithOne()
                       .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Quiz>()
                       .HasOne(x => x.UpdatedBy)
                       .WithOne()
                       .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
