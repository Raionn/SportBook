using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Type { get; set; }
        public string CreationTime { get; set; }
        public string StartTime { get; set; }
        public string State { get; set; }
        public bool IsDeleted { get; set; }
        public bool HasStarted { get; set; }
        public List<User> ParticipantList { get; set; }
        public User Author { get; set; }
        public List<Message> Messages { get; set; }
    }
}
