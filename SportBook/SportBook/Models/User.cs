using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Models
{
    public class User
    {
        String Username { get; set; }
        String Password { get; set; }
        String Nickname { get; set; }
        String GameAcccount { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Nickname = "";
            GameAcccount = "";
        }
    }
}
