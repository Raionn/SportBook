using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportBook.Controllers
{
    public class PlayerListController : Controller
    {
        public IActionResult PlayerListWindow()
        {
            if(ViewData["filter"] != null)
            {
                IList<string> players = new List<string>
                {
                    "alio",
                    "gerai"
                };

                ViewData["players"] = players;
            }
            else
            {
                ViewData["players"] = new List<string>();
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