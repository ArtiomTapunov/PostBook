using AutoMapper;
using PostBook.DomainObjects;
using PostBook.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostBook.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
