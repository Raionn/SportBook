using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportBook.Controllers
{
    public class EventController : Controller
    {
        public IActionResult EventList()
        {
            IList<string> events = new List<string>
            {
                "event_1",
                "event_2",
                "event_3",
                "( ͡° ͜ʖ ͡°)"
            };

            ViewData["events"] = events;

            return View();
        }

        public IActionResult EventForm()
        {

            return View();
        }

        public IActionResult EventWindow()
        {
            return View();
        }
    }
}