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

        public IActionResult ProfileWindow(string teamid)
        {
            ViewData["teams"] = getTeamsThatInvited();

            return View();
        }

        public ActionResult acceptInvitation(string id)
        {
            Invitation temp = _context.Invitations.Find(int.Parse(id));
            TeamMembers toAdd = new TeamMembers();
            toAdd.TeamId = temp.TeamId;
            toAdd.UserId = temp.UserId;

            _context.Add(toAdd);
            _context.Remove(temp);
            _context.SaveChanges();            

            return RedirectToAction("ProfileWindow", "Team", new { id });
        }

        public ActionResult rejectInvitation(string id)
        {
            Invitation temp = _context.Invitations.Find(int.Parse(id));
            _context.Remove(temp);
            _context.SaveChanges();

            return RedirectToAction("ProfileWindow", "Team", new { id });
        }

        public IActionResult getTeamsThatInvited(int userid = 1)
        {
            return View(_context.Invitations.Where(s => s.UserId == userid));
        }

        public IActionResult TeamManagementWindow(int teamid, string name, int userid = 1)
        {
            ViewData["teamid"] = teamid;
            ViewData["name"] = name;
            ViewData["userid"] = userid;
            Team temp = _context.Teams.Find(teamid);
            string creator = "false";
            if(temp.UserId == userid)
            {
                creator = "true";
            }
            ViewData["players"] = getPlayerList();
            ViewData["creator"] = creator;
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
            temp.Text = name;
            List<Invitation> allData = _context.Invitations.ToList();
            int index = allData.FindIndex(item => item.UserId == temp.UserId && item.TeamId == temp.TeamId);
            if (index < 0)
            {
                _context.Add(temp);
                _context.SaveChanges();
            }

            return RedirectToAction("TeamManagementWindow" , "Team", new { teamid, name });
        }


        public ActionResult removePlayerFromTeam(string teamid, int uId = 1)
        {
            TeamMembers temp = new TeamMembers();
            temp.TeamId = int.Parse(teamid);
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