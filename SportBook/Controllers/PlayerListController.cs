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

            //TODO: call database
            List<string> players = new List<string>
                {
                    "alio",
                    "gerai"
                };

            if (ViewData["filter"] != null)
            {
                var resultList = players.FindAll(delegate (string s) { return s.Contains(filter); });

                ViewData["players"] = resultList;
            }
            else
            {
                ViewData["players"] = players;
            }
            

            return View();
        }
    }
}