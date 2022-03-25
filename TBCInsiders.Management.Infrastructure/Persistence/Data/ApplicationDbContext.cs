using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.Domain.Entities;
using TBCInsiders.Management.Infrastructure.Persistence.EntityTypeConfigurations.UserEntityTypeConfiguration;

namespace TBCInsiders.Management.Infrastructure.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserConnections> UserConnections { get; set; }
        public DbSet<ConnectedUser> ConnectedUsers { get; set; }
        public DbSet<UserConnectionType> UserConnectionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserConnections>().HasOne(x => x.User).WithMany(x => x.UserConnections).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Gender>().HasData(new Gender
            {
                Id = 1,
                Value = "Male"
            });
            modelBuilder.Entity<Gender>().HasData(new Gender
            {
                Id = 2,
                Value = "Female"
            });
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 1,
                Name = "Tbilisi"
            });
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 2,
                Name = "Kutaisi"
            });
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 3,
                Name = "Batumi"
            });

            modelBuilder.Entity<PhoneNumberType>().HasData(new PhoneNumberType
            {
                Id = 1,
                Value = "Mobile"
            });
            modelBuilder.Entity<PhoneNumberType>().HasData(new PhoneNumberType
            {
                Id = 2,
                Value = "Home"
            });
            modelBuilder.Entity<PhoneNumberType>().HasData(new PhoneNumberType
            {
                Id = 3,
                Value = "Office"
            });

            modelBuilder.Entity<UserConnectionType>().HasData(new UserConnectionType
            {
                Id = 1,
                Name = "Colegue"
            });
            modelBuilder.Entity<UserConnectionType>().HasData(new UserConnectionType
            {
                Id = 2,
                Name = "Relative"
            });
            modelBuilder.Entity<UserConnectionType>().HasData(new UserConnectionType
            {
                Id = 3,
                Name = "Acquaintance"
            });
            modelBuilder.Entity<UserConnectionType>().HasData(new UserConnectionType
            {
                Id = 4,
                Name = "Other"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "irakli",
                LastName = "ordenidze",
                PersonalNumber = "01008042010",
                DateOfBirth = DateTime.Parse("1996-05-02"),
                CityId = 1,
                GenderId = 1,
            });

            modelBuilder.Entity<PhoneNumber>().HasData(new PhoneNumber
            {

                Id = 1,
                Phone = "555900563",
                TypeID = 1,
                UserId = 1
            });
            modelBuilder.Entity<ConnectedUser>().HasData(new ConnectedUser
            {
                FirstName = "lasha",
                LastName = "Lejava",
                PersonalNumber = "12345687910",
                Phone = "555900001",
                Id = 1
            });

            modelBuilder.Entity<UserConnections>().HasData(new UserConnections
            {
                Id = 1,
                ConnectedUserId = 1,
                UserId = 1,
                ConnectionTypeId = 1
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
