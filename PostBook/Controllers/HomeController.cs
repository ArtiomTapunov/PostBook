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

namespace PostBook.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public HomeController(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userService.GetUser(User);
            var messages = await _messageService.GetAllMessages();

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }

            return View(messages);
        }

        public async Task<IActionResult> CreateMessage(Message message)
        {
            if(ModelState.IsValid)
            {
                await _messageService.CreateMessage(message, User);

                return Ok();
            }

            return Error();
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
