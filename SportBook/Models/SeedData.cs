﻿using Microsoft.EntityFrameworkCore;
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
               
                if (context.Users.Any())
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
                context.SaveChanges();
            }
        }
    }
}