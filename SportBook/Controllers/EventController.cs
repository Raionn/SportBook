using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using SportBook.Models;

namespace SportBook.Controllers
{
    public class EventController : Controller
    {
        public IActionResult EventList()
        {
            //TODO: getEventList()
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

        public ActionResult cancelEvent(string id)
        {
            //TODO: deleteEvent(id)
            
            return RedirectToAction("EventList");
        }

        public IActionResult EventForm(string id)
        {
            ViewData["id"] = id;

            return View();
        }

        public IActionResult EventWindow(string id)
        {
            ViewData["id"] = id;
            return View();
        }

        public ActionResult submitChanges(string id)
        {
            //TODO: validate

            string name = String.Format("{0}", Request.Form["name"]);
            var game = String.Format("{0}", Request.Form["selectedGame"]);
            //if (Request.Form["datetimepicker"].Equals(null))
            //{
            //    return RedirectToAction("EventForm", "Event", new { id = "error"});
            //}
            try
            {
                var date = Convert.ToDateTime(String.Format(Request.Form["datetimepicker"]));

            }
            catch
            {
                //display error
                return RedirectToAction("Error");
            }

            //TODO: update event


            return RedirectToAction("EventWindow", "Event", new { id });
        }

        public ActionResult SubmitParticipation(string id)
        {
            //TODO: updateParticipantList()

            return RedirectToAction("EventWindow", "Event", new { id });
        }

        public ActionResult CancelParticipation(string id)
        {
            //TODO: updateParticipantList()

            return RedirectToAction("EventWindow", "Event", new { id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}