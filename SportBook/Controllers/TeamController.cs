using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportBook.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult MyTeamsWindow()
        {
            ViewData["teams"] = getTeamsAssociatedWithPlayer();
            return View();
        }

        public IActionResult TeamList(string filter)
        {
            ViewData["filter"] = filter;

            if (ViewData["filter"] != null)
            {
                ViewData["teams"] = getFilteredTeamList(filter);
            }
            else
            {
                ViewData["teams"] = getTeamList();
            }

            return View();
        }

        public IActionResult ProfileWindow()
        {
            return View();
        }

        public IActionResult TeamManagementWindow(string id)
        {
            ViewData["team"] = id;
            ViewData["players"] = getPlayerList();
            return View();
        }

        public List<string> getPlayerList()
        {
            return new List<string>
                {
                    "žaidėjas1",
                    "žaidėjas2",
                    "žaidėjas3",
                    "žaidėjas4",
                    "žaidėjas5",
                    "žaidėjas6",
                };
        }

        public ActionResult sendInvitationToSelectedPlayer(string id)
        {
            //TODO: saveInvitation()

            return RedirectToAction("TeamManagementWindow" , "Team", new { id });
        }


        public ActionResult removePlayerFromTeam(string id)
        {
            //TODO: removePlayerFromTeam(id)

            return RedirectToAction("MyTeamsWindow");
        }

        public List<string> getTeamsAssociatedWithPlayer()
        {
            //TODO: query database

            return new List<string>
                {
                    "manokomanda1",
                    "manokomanda2",
                    "manokomanda3"
                };
        }

        public List<string> getTeamList()
        {
            //TODO: query database

            return new List<string>
                {
                    "komanda1",
                    "komanda2",
                    "komanda3"
                };
        }

        public List<string> getFilteredTeamList(string filter)
        {
            //TODO: query database

            List<string> players = new List<string>
                {
                    "filtruotaKomanda1",
                    "filtruotaKomanda2",
                    "filtruotaKomanda3",
                    "filtruotaKomanda4",
                    "filtruotaKomanda5",
                    "filtruotaKomanda6",
                };

            var resultList = players.FindAll(delegate (string s) { return s.Contains(filter); });

            return resultList;
        }
    }
}