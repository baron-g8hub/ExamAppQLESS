﻿using Common;
using Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Common
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<RAWSMARTCARD> RAWSMARTCARDs => Set<RAWSMARTCARD>();
        public DbSet<TrainStation> TrainStations => Set<TrainStation>();
        public DbSet<TransportCardTrip> TransportCardTrips => Set<TransportCardTrip>();
        public DbSet<TransportCard> TransportCards => Set<TransportCard>();
        public DbSet<CardTransaction> CardTransactions => Set<CardTransaction>();

        public DbSet<GenEmpUID> GenEmpUIDs => Set<GenEmpUID>();
        public DbSet<Employee> Employees => Set<Employee>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var converter = new BoolToZeroOneConverter<int>();
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //  builder.Entity<RAWSMARTCARD>().Property(e => e.IsActive).HasConversion(converter);

            builder.Entity<GenEmpUID>().Property(p => p.GeneratedID).UseIdentityColumn(1001, 1);
            builder.Entity<GenEmpUID>().Property(p => p.RowVersion).IsRowVersion();
            builder.Entity<GenEmpUID>().Property(p => p.IsActive).HasDefaultValue(0);
            builder.Entity<Employee>().Property(p => p.RowVersion).IsRowVersion();
            builder.Entity<RAWSMARTCARD>().Property(p => p.RowVersion).IsRowVersion();
            builder.Entity<TransportCard>().Property(p => p.RowVersion).IsRowVersion();
            builder.Entity<TrainStation>().Property(p => p.RowVersion).IsRowVersion();
            builder.Entity<TrainStation>().Property(b => b.TrainStationID).ValueGeneratedOnAdd();
            builder.Entity<CardTransaction>().Property(p => p.RowVersion).IsRowVersion();
            builder.Entity<TransportCardTrip>().Property(p => p.RowVersion).IsRowVersion();

            builder.Entity<GenEmpUID>()
                  .HasOne(b => b.Employee)
                  .WithOne(i => i.GenEmpUID)
                  .HasForeignKey<Employee>(b => b.EmployeeUID);

            //builder.Entity<RAWSMARTCARD>()
            //     .HasMany(c => c.TransportCards)
            //     .WithOne(e => e.RAWSMARTCARD);

            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST1",
                TrainStationNumber = 1,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });

            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST2",
                TrainStationNumber = 2,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });
            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST3",
                TrainStationNumber = 3,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });
            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST4",
                TrainStationNumber = 4,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });
            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST5",
                TrainStationNumber = 5,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });
            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST6",
                TrainStationNumber = 6,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });
            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST7",
                TrainStationNumber = 7,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });
            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST8",
                TrainStationNumber = 8,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });
            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST9",
                TrainStationNumber = 9,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });
            builder.Entity<TrainStation>().HasData(new TrainStation
            {
                TrainStationID = Guid.NewGuid(),
                TrainStationCode = "ST10",
                TrainStationNumber = 10,
                IsActive = true,
                CreatedBy = "ADMIN",
                UpdatedBy = "ADMIN"
            });

            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                RoleLevel = 100,
            });
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Manager",
                NormalizedName = "MANAGER",
                RoleLevel = 200,
            });
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Clerk",
                NormalizedName = "CLERK",
                RoleLevel = 300,
            });
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER",
                RoleLevel = 400,
            });

            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 1,
                SmartCardName = "RFID111",
                SerialNumber = 111,
                IsActive = false,
                IsValid = true,
            });
            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 2,
                SmartCardName = "RFID222",
                SerialNumber = 222,
                IsActive = false,
                IsValid = true,
            });
            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 3,
                SmartCardName = "RFID333",
                SerialNumber = 333,
                IsActive = false,
                IsValid = true,
            });
            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 4,
                SmartCardName = "RFID444",
                SerialNumber = 444,
                IsActive = false,
                IsValid = true,
            });
            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 5,
                SmartCardName = "RFID555",
                SerialNumber = 555,
                IsActive = false,
                IsValid = true,
            });
            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 6,
                SmartCardName = "RFID666",
                SerialNumber = 666,
                IsActive = false,
                IsValid = true,
            });
            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 7,
                SmartCardName = "RFID777",
                SerialNumber = 777,
                IsActive = false,
                IsValid = true,
            });
            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 8,
                SmartCardName = "RFID888",
                SerialNumber = 888,
                IsActive = false,
                IsValid = true,
            });
            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 9,
                SmartCardName = "RFID999",
                SerialNumber = 999,
                IsActive = false,
                IsValid = true,
            });
            builder.Entity<RAWSMARTCARD>().HasData(new RAWSMARTCARD
            {
                SmartCardID = 10,
                SmartCardName = "RFID1010",
                SerialNumber = 1010,
                IsActive = false,
                IsValid = true,
            });
        }
    }
}















