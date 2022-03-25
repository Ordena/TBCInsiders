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
    class UserConnectionsEntityTypeConfiguration : IEntityTypeConfiguration<UserConnections>
    {
        public void Configure(EntityTypeBuilder<UserConnections> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.UserConnections).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
