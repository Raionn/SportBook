using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportBook.Models;

namespace SportBook.Controllers
{
    public class TeamController : Controller
    {
        private readonly Context _context;

        public TeamController(Context context)
        {
            _context = context;
        }

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

        public IActionResult ProfileWindow(string id)
        {
            ViewData["teams"] = getTeamsThatInvited();

            return View();
        }

        public ActionResult acceptInvitation(string id)
        {
            //TODO: addUserToMembers()

            return RedirectToAction("ProfileWindow", "Team", new { id });
        }

        public ActionResult rejectInvitation(string id)
        {
            //TODO: removeInvitation()
            //TODO: sendRejectionMessage()

            return RedirectToAction("ProfileWindow", "Team", new { id });
        }

        public List<string> getTeamsThatInvited()
        {
            //TODO: query database

            return new List<string>
                {
                    "kvieciantikomanda1",
                    "kvieciantikomanda2",
                    "kvieciantikomanda3",
                };
        }

        public IActionResult TeamManagementWindow(int teamid, string name)
        {
            ViewData["teamid"] = teamid;
            ViewData["name"] = name;
            ViewData["players"] = getPlayerList();
            return View();
        }

        public IActionResult getPlayerList()
        {
            return View(_context.Users.ToList());
        }

        public ActionResult sendInvitationToSelectedPlayer(int teamid, int userid, string name)
        {
            Invitation temp = new Invitation();
            temp.TeamId = teamid;
            temp.UserId = userid;
            List<Invitation> allData = _context.Invitations.ToList();
            int index = allData.FindIndex(item => item.UserId == temp.UserId && item.TeamId == temp.TeamId);
            if (index < 0)
            {
                _context.Add(temp);
                _context.SaveChanges();
            }

            return RedirectToAction("TeamManagementWindow" , "Team", new { teamid, name });
        }


        public ActionResult removePlayerFromTeam(string id, int uId = 1)
        {
            TeamMembers temp = new TeamMembers();
            temp.TeamId = int.Parse(id);
            temp.UserId = uId;
            List<TeamMembers> allData = _context.TeamMembers.ToList();
            int index = allData.FindIndex(item => item.UserId == temp.UserId && item.TeamId == temp.TeamId);
            if (index >= 0)
            {
                TeamMembers toDelete = allData[index];
                _context.Remove(toDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("MyTeamsWindow");
        }

        public IActionResult getTeamsAssociatedWithPlayer(int id = 1)
        {
            IEnumerable<TeamMembers> teamMembers = _context.TeamMembers.Where(s => s.UserId == id);
            List<int> indexes = new List<int>();
            foreach(TeamMembers value in teamMembers)
            {
                indexes.Add(value.TeamId);
            }
            return View(_context.Teams.Where(s => indexes.Contains(s.TeamId)));
        }

        public IActionResult getTeamList()
        {
            return View(_context.Teams.ToList());
        }

        public IActionResult getFilteredTeamList(string filter)
        {
            return View(_context.Teams.Where(s => s.TeamName.Contains(filter)));
        }
    }
}