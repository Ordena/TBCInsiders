
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;
using TBCInsiders.Management.ApplicationCore.Models.User;
using TBCInsiders.Management.Domain.Entities;

namespace TBCInsiders.Management.ApplicationCore.Profiles.UserProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>().ForMember(x => x.Image,options => options.Ignore());
            CreateMap<User, UserDto>();
           
            CreateMap<User, UserDetailsDto>()
                .ForMember(x => x.Gender, options => options.MapFrom(src => src.Gender.Value))
                .ForMember(x => x.City, options => options.MapFrom(src => src.City.Name))
                .ForMember(x => x.PhoneNumbers, options => options.MapFrom(src => src.PhoneNumbers))
                //.ForMember(x => x.UserConnections, options => options.MapFrom(src => src.UserConnections.Select(uc => uc.ConnectedUser)))
                .ForMember(x => x.UserConnections, options => options.MapFrom(src => src.UserConnections))
                .ReverseMap();

            CreateMap<EditUserDto, User>();
            //CreateMap<EditUserDto, User>().ForMember(x => x.PhoneNumbers, options => options.MapFrom( src => src.PhoneNumbers));
        }
    }
}
