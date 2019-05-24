using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportBook.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Message> Messages { get; set; }
        
        
    }
    //static List<User> getPlayerList()
    //{
    //    return null;
    //}
}
