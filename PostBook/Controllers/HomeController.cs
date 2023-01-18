using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostBook.DataAccess;
using PostBook.DomainObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PostBook.Models;
using PostBook.Services.Interfaces;
using PostBook.Services.Dtos;
using Microsoft.AspNetCore.SignalR;
using PostBook.Hubs;

namespace PostBook.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly IRoomService _roomService;

        public HomeController(IUserService userService, IMessageService messageService, IRoomService roomService)
        {
            _userService = userService;
            _messageService = messageService;
            _roomService = roomService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userService.GetUser(User);

            var chats = await _roomService.GetRoomsToJoin(currentUser.Id);

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }

            return View(chats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Chat(Guid id)
        {
            return View(await _roomService.GetRoom(id));
        }

        public async Task<IActionResult> CreateMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                await _messageService.CreateMessage(message, User);

                return RedirectToAction("Chat", new { id = message.ChatId });
            }

            return Error();
        }

        public async Task<IActionResult> SendMessage(Message message, [FromServices] IHubContext<ChatHub> chat)
        {
            var createdMessage = await _messageService.CreateMessage(message, User);

            await chat.Clients.Group(message.ChatId.ToString())
                .SendAsync("RecieveMessage", new
                {
                    Text = createdMessage.Text,
                    UserName = createdMessage.UserName,
                    CreatedDate = createdMessage.CreatedDate.ToString("dd/MM/yyyy hh:mm:ss")
                });

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            var currentUser = await _userService.GetUser(User);
            await _roomService.CreateRoom(name, currentUser.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> JoinRoom(Guid id)
        {
            var currentUser = await _userService.GetUser(User);
            await _roomService.JoinRoom(id, currentUser.Id);

            return RedirectToAction("Chat", "Home", new { id });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
