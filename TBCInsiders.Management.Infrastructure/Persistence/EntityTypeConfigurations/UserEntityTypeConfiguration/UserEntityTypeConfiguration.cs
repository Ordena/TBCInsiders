
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.Infrastructure.Persistence.EntityTypeConfigurations.UserEntityTypeConfiguration
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.UserConnections).WithOne(x => x.User).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.PersonalNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).IsRequired();
        }
    }
}
