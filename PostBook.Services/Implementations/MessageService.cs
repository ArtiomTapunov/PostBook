using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostBook.DataAccess;
using PostBook.DomainObjects;
using PostBook.Services.Dtos;
using PostBook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PostBook.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MessageService(ApplicationDbContext context, IUserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Message> CreateMessage(Message message, ClaimsPrincipal user)
        {
            var sender = await _userService.GetUser(user);

            message.UserName = user.Identity.Name;
            message.UserId = sender.Id;
            message.CreatedDate = DateTime.UtcNow;

            //var messageToAdd = _mapper.Map<Message>(message);
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message;
        }

        public async Task<IReadOnlyCollection<Message>> GetAllMessages()
        {
            var allMessages = await _context.Messages.AsNoTracking().ToListAsync();

            return allMessages;
        }

        public Task<MessageDto> GetMessageById()
        {
            throw new NotImplementedException();
        }
    }
}
