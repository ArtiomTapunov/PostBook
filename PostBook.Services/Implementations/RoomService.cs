using Microsoft.EntityFrameworkCore;
using PostBook.DataAccess;
using PostBook.DomainObjects;
using PostBook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostBook.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Chat> GetRoom(Guid roomId)
        {
            return await _context.Chats
                .AsNoTracking()
                .Include(x => x.Messages)
                .SingleOrDefaultAsync(x => x.Id == roomId);
        }

        public async Task<IEnumerable<Chat>> GetRoomsToJoin(string userId)
        {
            return await _context.Chats
                .Include(x => x.Users)
                .Where(x => !x.Users.Any(y => y.UserId == userId))
                .ToListAsync();
        }

        public IEnumerable<Chat> GetUserRooms(string userId)
        {
            return _context.ChatUsers
                            .Include(x => x.Chat)
                            .Where(x => x.UserId == userId)
                            .Select(x => x.Chat)
                            .ToList();
        }

        public async Task CreateRoom(string name, string userId)
        {
            var chat = new Chat
            {
                Name = name
            };

            chat.Users.Add(new ChatUser
            {
                UserId = userId,
            });

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();
        }

        public async Task JoinRoom(Guid chatId, string userId)
        {
            var chatUser = new ChatUser
            {
                ChatId = chatId,
                UserId = userId,
            };

            _context.ChatUsers.Add(chatUser);

            await _context.SaveChangesAsync();
        }
    }
}
