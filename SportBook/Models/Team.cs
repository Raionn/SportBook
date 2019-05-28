using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public Type Type { get; set; }

        public int UserId { get; set; }
        public List<TeamMembers> TeamMembers { get; set; }
    }
    public enum Type
    {
        Football,
        Basketball,
        Volleyball,
        LoL
    }
}
