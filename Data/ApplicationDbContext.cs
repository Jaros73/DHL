using DHL.Models;
using Microsoft.EntityFrameworkCore;

namespace DHL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<IrregularCourse> IrregularCourses { get; set; }
        public DbSet<Machining> Machinings { get; set; }
        public DbSet<RegionalReport> RegionalReports { get; set; }
        public DbSet<Remainder> Remainders { get; set; }
        public DbSet<Crate> Crates { get; set; }
        public DbSet<TechnologicalGroup> TechnologicalGroups { get; set; }
        public DbSet<Delay> Delays { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationAssignment> LocationAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<LocationAssignment>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.LocationAssignments)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<LocationAssignment>()
                .HasOne(l => l.Location)
                .WithMany(l => l.LocationAssignments)
                .HasForeignKey(l => l.LocationId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Location)
                .WithMany(l => l.Courses)
                .HasForeignKey(c => c.LocationId);

        }
    }
}
