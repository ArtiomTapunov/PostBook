using System;
using System.Collections.Generic;
using System.Text;

namespace PostBook.DomainObjects
{
    public class ChatUser
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public Guid ChatId { get; set; }

        public Chat Chat { get; set; }
    }
}
