using System;
using System.ComponentModel.DataAnnotations;

namespace PostBook.DomainObjects
{
    public class Message
    {
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        public virtual User Sender { get; set; }

        public Guid ChatId { get; set; }

        public Chat Chat { get; set; }
    }
}
