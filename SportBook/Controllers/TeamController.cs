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
            return View();
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