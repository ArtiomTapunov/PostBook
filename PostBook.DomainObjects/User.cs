using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PostBook.DomainObjects
{
    public class User : IdentityUser
    {
        public virtual ICollection<Message> Messages { get; set; }
    }
}
