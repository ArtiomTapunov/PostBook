using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalTestApp.Models
{
    public class MessageDto
    {
        public string UserName { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public string DateToDisplay { get; set; }
    }
}
