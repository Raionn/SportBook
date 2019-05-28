using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Models
{
    public class Invitation
    {
        public int InvitationId { get; set; }
        public string Text { get; set; }

        public int UserId { get; set; }
        public int TeamId { get; set; }
    }
}
