using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Profiles.ConnectedUserProfile
{
    public class ConnectedUserProfile : Profile
    {
        public ConnectedUserProfile()
        {
            CreateMap<ConnectedUser, ConnectedUserDto>().ReverseMap();
        }
    }
}
