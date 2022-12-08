using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PostBook.DataAccess;
using PostBook.DomainObjects;
using PostBook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PostBook.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserService(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsers() =>
            await _context.ApplicationUsers.AsNoTracking().ToListAsync();

        public async Task<User> GetUser(ClaimsPrincipal user) =>
            await _userManager.GetUserAsync(user);

        public Task<User> GetUserById()
        {
            throw new NotImplementedException();
        }
    }
}
