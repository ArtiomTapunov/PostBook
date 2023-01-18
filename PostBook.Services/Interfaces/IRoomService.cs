using PostBook.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostBook.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Chat> GetRoom(Guid roomId);

        Task CreateRoom(string name, string userId);

        Task JoinRoom(Guid chatId, string userId);

        Task<IEnumerable<Chat>> GetRoomsToJoin(string userId);

        IEnumerable<Chat> GetUserRooms(string userId);
    }
}
