using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int EventId { get; set; }
        public string Text { get; set; }
    }
}
