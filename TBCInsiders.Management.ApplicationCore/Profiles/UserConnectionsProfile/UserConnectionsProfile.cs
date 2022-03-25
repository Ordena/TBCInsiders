using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;
using TBCInsiders.Management.ApplicationCore.Models.UserConnection;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Profiles.UserConnectionsProfile
{
    public class UserConnectionsProfile :Profile
    {
        public UserConnectionsProfile()
        {
            CreateMap<ConnectedUser, ConnectedUserDto>();
            CreateMap<UserConnections, UserConnectionDto>();
            //CreateMap<UserConnections, ConnectedUserDto>()
            //    .ForMember(x => x.LastName, options => options.MapFrom(x => x.ConnectedUser.LastName))
            //    .ForMember(x => x.PersonalNumber, options => options.MapFrom(x => x.ConnectedUser.PersonalNumber))
            //    .ForMember(x => x.Phone, options => options.MapFrom(x => x.ConnectedUser.Phone))
            //    .ForMember(x => x.ConnectionTypeId, options => options.MapFrom(x => x.ConnectionTypeId))
            //    .ForMember(x => x.FirstName, options => options.MapFrom(x => x.ConnectedUser.FirstName));
        }
    }
}
