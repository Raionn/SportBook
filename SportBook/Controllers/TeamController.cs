using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportBook.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult TeamList()
        {
            ViewData["teams"] = getTeamsAssociatedWithPlayer();
            return View();
        }

        public List<string> getTeamsAssociatedWithPlayer()
        {
            //TODO: query database

            return new List<string>
                {
                    "komanda1",
                    "komanda2",
                    "komanda3"
                };
        }

        public IActionResult MyTeamsWindow()
        {
            return View();
        }

        public IActionResult ProfileWindow()
        {
            return View();
        }

        public IActionResult TeamManagementWindow()
        {
            return View();
        }
    }
}