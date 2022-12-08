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

namespace PostBook.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<User> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var messages = await _context.Messages.ToListAsync();

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
                var sender = await _userManager.GetUserAsync(User);

                message.UserName = User.Identity.Name;
                message.UserId = sender.Id;
                message.CreatedDate = DateTime.UtcNow;

                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();

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
