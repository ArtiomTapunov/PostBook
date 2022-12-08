using PostBook.DomainObjects;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PostBook.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(ClaimsPrincipal user);

        Task<User> GetUserById();

        Task<IReadOnlyCollection<User>> GetAllUsers();
    }
}
