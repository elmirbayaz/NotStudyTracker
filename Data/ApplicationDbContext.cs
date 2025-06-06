using Microsoft.EntityFrameworkCore;
using StudyTracker.Models;

namespace StudyTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Assignment> Assignments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>()
                .Property(a => a.Deadline)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<Assignment>()
                .Property(a => a.Status)
                .HasConversion<string>();
        }
    }
}
