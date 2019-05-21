using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportBook.Controllers
{
    public class PlayerListController : Controller
    {
        public IActionResult PlayerListWindow(string filter)
        {
            ViewData["filter"] = filter;

            if (ViewData["filter"] != null)
            {
                ViewData["players"] = getFilteredPlayers(filter);
            }
            else
            {
                ViewData["players"] = new List<string>();
            }
            

            return View();
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