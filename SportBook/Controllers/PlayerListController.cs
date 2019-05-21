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
                
                List<string> players = new List<string>
                {
                    "alio",
                    "gerai"
                };

                var resultList = players.FindAll(delegate (string s) { return s.Contains(filter); });

                ViewData["players"] = resultList;
            }
            else
            {
                List<string> players = new List<string>
                {
                    "alio",
                    "gerai"
                };

                ViewData["players"] = players;
            }
            

            return View();
        }

        

        public void GetFilteredPlayers()
        {
            IList<string> players = new List<string>
            {
                "alio",
                "gerai"
            };

            ViewData["players"] = players;
        }
    }
}