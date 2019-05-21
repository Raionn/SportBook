using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportBook.Controllers
{
    public class EventController : Controller
    {
        public IActionResult EventsList()
        {
            return View();
        }
    }
}