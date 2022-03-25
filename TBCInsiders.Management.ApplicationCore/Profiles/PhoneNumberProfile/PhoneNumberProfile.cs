using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.PhoneNumber;
using TBCInsiders.Management.ApplicationCore.Models.User;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Profiles.PhoneNumberProfile
{
    public class PhoneNumberProfile : Profile
    {
        public PhoneNumberProfile()
        {
            
            CreateMap<PhoneNumber, PhoneNumberDetailsDto>().ForMember(x => x.Type, options => options.MapFrom(src => src.Type.Value));
            CreateMap<PhoneNumber, PhoneNumberDto>()
                .ReverseMap();
        }
    }
}
