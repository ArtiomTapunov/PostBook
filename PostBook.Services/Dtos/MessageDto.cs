using System;
using System.Collections.Generic;
using System.Text;

namespace PostBook.Services.Dtos
{
    public class MessageDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        public virtual UserDto Sender { get; set; }
    }
}
