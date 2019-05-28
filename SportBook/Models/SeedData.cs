using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SportBook.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Context>>()))
            {

                if (context.Users.Any() && context.Teams.Any() && context.TeamMembers.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        Username = "Petras",
                        Password = "zeus123",
                        Nickname = "Dzeusas",
                        Game_account = "EpicGamer200"
                    },

                    new User
                    {
                        Username = "Jonas",
                        Password = "katinas",
                        Nickname = "Jonce",
                        Game_account = "JonelisLTU"
                    },

                    new User
                    {
                        Username = "Vycka",
                        Password = "aaaa",
                        Nickname = "Cycka",
                        Game_account = "1v1Me"
                    },

                    new User
                    {
                        Username = "Rope",
                        Password = "123a",
                        Nickname = "DarzeGimes",
                        Game_account = "DirvojeAuges"
                    }
                );
                context.Teams.AddRange(
                    new Team
                    {
                        TeamName = "Viespaties lelijos",
                        Type = Type.LoL,
                        UserId = 1
                    },

                    new Team
                    {
                        TeamName = "Berzo zieve",
                        Type = Type.Basketball,
                        UserId = 2
                    },

                    new Team
                    {
                        TeamName = "Riteriai",
                        Type = Type.Football,
                        UserId = 3
                    },

                    new Team
                    {
                        TeamName = "Rudupio vilkai",
                        Type = Type.Volleyball,
                        UserId = 3
                    },

                    new Team
                    {
                        TeamName = "Instant karma",
                        Type = Type.LoL,
                        UserId = 2
                    }
                );
                context.SaveChanges();

                context.TeamMembers.AddRange(
                    new TeamMembers
                    {
                        TeamId = 1,
                        UserId = 1
                    },

                    new TeamMembers
                    {
                        TeamId = 3,
                        UserId = 1
                    }
                );
                context.Invitations.AddRange(
                    new Invitation
                    {
                        TeamId = 4,
                        UserId = 1
                    },

                    new Invitation
                    {
                        TeamId = 5,
                        UserId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
