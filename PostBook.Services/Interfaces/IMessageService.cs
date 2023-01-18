using PostBook.DomainObjects;
using PostBook.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PostBook.Services.Interfaces
{
    public interface IMessageService
    {
        Task<MessageDto> GetMessageById();

        Task<IReadOnlyCollection<Message>> GetAllMessagesByChatId(Guid chatId);

        Task<Message> CreateMessage(Message message, ClaimsPrincipal user);
    }
}
