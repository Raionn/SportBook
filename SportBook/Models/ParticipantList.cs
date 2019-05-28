using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Models
{
    public class ParticipantList
    {
        public int ParticipantListId { get; set; }

        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}