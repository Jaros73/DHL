using Microsoft.EntityFrameworkCore;
using DHL.Models;
using System.Net.Mail;

namespace DHL.Data;

public class ApplicationDbContext : DbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<LocationAssignment> LocationAssignments { get; set; }
    public DbSet<Dispatch> Dispatches { get; set; }
    public DbSet<IrregularCourse> IrregularCourses { get; set; }
    public DbSet<Machining> Machinings { get; set; }
    public DbSet<RegionalReport> RegionalReports { get; set; }
    public DbSet<Remainder> Remainders { get; set; }
    public DbSet<Crate> Crates { get; set; }
    public DbSet<TechnologicalGroup> TechnologicalGroups { get; set; }
    public DbSet<Delay> Delays { get; set; }
    public DbSet<Transporter> Transporters { get; set; }
    public DbSet<Models.Attachment> Attachments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definice Many-To-Many pro Employee ↔ Location
        modelBuilder.Entity<LocationAssignment>()
            .HasKey(e => new { e.EmployeeId, e.LocationId });

        modelBuilder.Entity<LocationAssignment>()
            .HasOne(e => e.Employee)
            .WithMany(e => e.LocationAssignments)
            .HasForeignKey(e => e.EmployeeId);

        modelBuilder.Entity<LocationAssignment>()
            .HasOne(e => e.Location)
            .WithMany(l => l.LocationAssignments)
            .HasForeignKey(e => e.LocationId);
    }
}
