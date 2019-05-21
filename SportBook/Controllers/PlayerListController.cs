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
                getFilteredPlayers(filter);
            }
            else
            {
                ViewData["players"] = new List<string>();
            }
            

            return View();
        }

        public void getFilteredPlayers(string filter)
        {
            //TODO: query database

            List<string> players = new List<string>
                {
                    "alio",
                    "gerai"
                };

            var resultList = players.FindAll(delegate (string s) { return s.Contains(filter); });

            ViewData["players"] = resultList;
        }
    }
}