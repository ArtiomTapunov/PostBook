using Microsoft.AspNetCore.SignalR;
using PostBook.Services.Dtos;
using System.Threading.Tasks;

namespace PostBook.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(MessageDto message) =>
            Clients.All.SendAsync("RecieveMessage", message);

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
