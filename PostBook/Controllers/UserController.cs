using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostBook.DataAccess;
using PostBook.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostBook.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<User> _userManager;

        public UserController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var allUsers = await _context.ApplicationUsers.ToListAsync();

            return View(allUsers);
        }
    }
}
