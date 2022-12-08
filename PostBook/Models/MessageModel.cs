using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostBook.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        public virtual UserModel Sender { get; set; }
    }
}
