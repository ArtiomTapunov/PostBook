using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostBook.DataAccess;
using PostBook.Services.Interfaces;

namespace ChatApp.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        private readonly IRoomService _roomService;

        public RoomViewComponent(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = _roomService.GetUserRooms(userId);

            return View(chats);
        }
    }
}