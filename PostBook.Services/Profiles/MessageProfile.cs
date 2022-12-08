using AutoMapper;
using PostBook.DomainObjects;
using PostBook.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostBook.Services.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>();
            CreateMap<MessageDto, Message>();
        }
    }
}
