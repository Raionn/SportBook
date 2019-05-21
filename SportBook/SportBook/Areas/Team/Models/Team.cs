using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Areas.Team.Models
{
    public class Team
    {
        String Name { get; set; }
        String Type { get; set; }
        List<SportBook.Models.User> Players;

        public Team(string name, string type, List<SportBook.Models.User> players)
        {
            Name = name;
            Type = type;
            Players = new List<SportBook.Models.User>();
        }

        public void AddPlayer(SportBook.Models.User player) => Players.Add(player);


    }
}
