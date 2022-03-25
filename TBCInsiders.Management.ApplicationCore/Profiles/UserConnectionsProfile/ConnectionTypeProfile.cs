using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.ConnectionType;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Profiles.UserConnectionsProfile
{
    public class ConnectionTypeProfile : Profile
    {
        public ConnectionTypeProfile()
        {
            CreateMap<UserConnectionType, ConnectionTypeDto>().ForMember(x => x.ConnectionType, options => options.MapFrom(src => src.Name));
        }
    }
}
