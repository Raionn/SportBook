using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using SportBook.Models;
using Microsoft.EntityFrameworkCore;

namespace SportBook.Controllers
{
    public class EventController : Controller
    {
        private readonly Context _context;

        public EventController(Context context)
        {
            _context = context;
        }

        List<string> messages = new List<string>
            {
                "alio",
                "kaip sekas?",
                "gerai",
                "( ͡° ͜ʖ ͡°)"
            };

        //Task<IActionResult> Index()

        public async Task<IActionResult> EventList()
        {
            //TODO: getEventList()
            //IList<Event> events = await _context.Events.ToListAsync();

            //ViewData["events"] = events;

            return View(await _context.Events.ToListAsync());
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


            //TODO: selectAll() messages
            ViewData["messages"] = messages;

            return View();
        }

        public ActionResult submitMessage()
        {
            string message = String.Format("{0}", Request.Form["message"]);

            //TODO: save()


            return RedirectToAction("EventWindow");
        }

        public async Task<ActionResult> SubmitData()
        {
            DateTime date = new DateTime();

            string name = String.Format("{0}", Request.Form["name"]);
            var game = String.Format("{0}", Request.Form["selectedGame"]);

            try
            {
                date = Convert.ToDateTime(String.Format(Request.Form["datetimepicker"]));

            }
            catch
            {
                //display error
                return RedirectToAction("Error");
            }
            //public int EventId { get; set; }
            //public string EventName { get; set; }
            //public string Type { get; set; }
            //public string CreationTime { get; set; }
            //public string StartTime { get; set; }
            //public string State { get; set; }
            //public bool IsDeleted { get; set; }
            //public bool HasStarted { get; set; }

            //public User Author { get; set; }
            //public List<User> ParticipantList { get; set; }
            //public List<Message> Messages { get; set; }

            // TODO: createEvent();
            if (ModelState.IsValid)
            {
                var user = new User();
                user.UserId = 1;
                user.Game_account = "JonelisLTU";
                user.Nickname = "Jonce";
                user.Password = "katinas";
                user.Username = "Jonas";

                var eventToAdd = new Event();
                eventToAdd.EventName = name;
                eventToAdd.Type = game;
                eventToAdd.StartTime = date.ToString();
                eventToAdd.CreationTime = DateTime.Now.ToString();
                eventToAdd.HasStarted = false;
                eventToAdd.IsDeleted = false;
                //eventToAdd.Author = user;
                //eventToAdd.Messages = ;
                //eventToAdd.ParticipantList = 

                _context.Add(eventToAdd);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }

            //return View(@event);

            return RedirectToAction("EventList", "Event");
        }

        public ActionResult submitChanges(string id)
        {
            //TODO: validate

            string name = String.Format("{0}", Request.Form["name"]);
            var game = String.Format("{0}", Request.Form["selectedGame"]);
            try
            {
                var date = Convert.ToDateTime(String.Format(Request.Form["datetimepicker"]));

            }
            catch
            {
                //display error
                return RedirectToAction("Error");
            }

            //TODO: updateEvent()


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