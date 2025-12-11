using DayCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DayCare.Infrastructure.Data
{
    public class DayCareDbContext : DbContext
    {
        public DayCareDbContext(DbContextOptions<DayCareDbContext> options)
            : base(options)
        {
        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tutor>()
                .HasMany(t => t.Children)
                .WithOne(c => c.Tutor)
                .HasForeignKey(c => c.TutorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Child>()
                .HasMany(c => c.Attendances)
                .WithOne(a => a.Child)
                .HasForeignKey(a => a.ChildId);

            modelBuilder.Entity<Child>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Child)
                .HasForeignKey(m => m.ChildId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
