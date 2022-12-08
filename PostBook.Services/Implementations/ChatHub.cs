using Microsoft.AspNetCore.SignalR;
using PostBook.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostBook.Services.Implementations
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(MessageDto message) =>
            await Clients.All.SendAsync("receiveMessage", message);
    }
}
