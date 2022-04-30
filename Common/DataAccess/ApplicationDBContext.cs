using Common.DataAccess;
using Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<GenEmpUID>? GenEmpUIDs { get; set; }
        public DbSet<Employee>? Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<GenEmpUID>().Property(p => p.GeneratedID).UseIdentityColumn(1001, 1);
            builder.Entity<GenEmpUID>().Property(p => p.RowVersion).IsRowVersion();
            builder.Entity<GenEmpUID>().Property(p => p.IsActive).HasDefaultValue(0);
            builder.Entity<Employee>().Property(p => p.RowVersion).IsRowVersion();
            //builder.Entity<GeneratedEmployeeID>().Property(p => p.RecordNumber).ValueGeneratedOnAdd();
            //builder.Entity<GeneratedEmployeeID>().Property(p => p.RecordNumber).HasDefaultValueSql();

            //  builder.Entity<Employee>().HasOne(a => a.GeneratedEmployeeID).WithOne(b => b.Employee).HasForeignKey<GeneratedEmployeeID>(b => b.RecordNumber);
            builder.Entity<GenEmpUID>()
                  .HasOne(b => b.Employee)
                  .WithOne(i => i.GenEmpUID)
                  .HasForeignKey<Employee>(b => b.EmployeeUID);

            //  builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
    }
}


public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.UserUID).HasMaxLength(150);
        builder.Property(u => u.BranchCode).HasMaxLength(100);
    }
}



















