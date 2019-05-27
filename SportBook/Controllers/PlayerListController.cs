using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportBook.Models;

namespace SportBook.Controllers
{
    public class PlayerListController : Controller
    {
        private readonly Context _context;

        public PlayerListController(Context context)
        {
            _context = context;
        }
        public IActionResult PlayerListWindow(string filter)
        {
            ViewData["filter"] = filter;

            if (ViewData["filter"] != null)
            {
                ViewData["players"] = getFilteredPlayers(filter);
            }
            else
            {
                ViewData["players"] = getAllPlayers();
            }
            

            return View();
        }
        public async Task<IActionResult> getAllPlayers()
        {
            return View(await _context.Users.ToListAsync());
        }
        public List<string> getFilteredPlayers(string filter)
        {
            //TODO: query database

            List<string> players = new List<string>
                {
                    "žaidėjas1",
                    "žaidėjas2"
                };

            var resultList = players.FindAll(delegate (string s) { return s.Contains(filter); });

            return resultList;
        }

        public IActionResult UserProfileWindow(string id)
        {
            ViewData["user"] = id;
            return View();
        }
    }
}