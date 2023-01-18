using Microsoft.AspNetCore.SignalR;
using PostBook.Services.Dtos;
using System.Threading.Tasks;

namespace PostBook.Hubs
{
    public class ChatHub : Hub
    {
/*        public async Task SendMessage(MessageDto message) =>
            await Clients.All.SendAsync("receiveMessage", message);*/

        public Task JoinRoom(string roomId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        public Task LeaveRoom(string roomId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }
    }
}
