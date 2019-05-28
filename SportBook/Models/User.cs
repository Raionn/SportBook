using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Game_account { get; set; }

        public List<ParticipantList> ParticipantList { get; set; }
    }
}
