using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Models
{
    public class TeamMembers
    {
        public int TeamMembersId { get; set; }

        public int UserId { get; set; }
        public int TeamId { get; set; }
    }
}
