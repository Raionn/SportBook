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

        public IActionResult EventList()
        {
            return View(_context.Events.ToList());
        }

        public IActionResult CancelEvent(string id)
        {
            Event tmp = _context.Events.Find(int.Parse(id));
            tmp.IsDeleted = true;
            _context.Update(tmp);
            _context.SaveChanges();
            return RedirectToAction("EventList");
        }

        public IActionResult EventForm(string id, string eventname, string type, string starttime)
        {
            ViewData["id"] = id;
            ViewData["eventname"] = eventname;
            ViewData["type"] = type;
            ViewData["starttime"] = starttime;
            return View();
        }

        public IActionResult EventWindow(string id, string eventname, string type, string starttime)
        {
            ViewData["id"] = id;

            //TODO: selectAll() messages
            ViewData["eventname"] = eventname;
            ViewData["type"] = type;
            ViewData["starttime"] = starttime;

            return View(_context.Messages.ToList());
        }

        public ActionResult submitMessage(string id)
        {
            string message = String.Format("{0}", Request.Form["message"]);
            Message tmp = new Message();
            tmp.EventId = int.Parse(id);
            tmp.Text = message;
            _context.Messages.Add(tmp);
            //TODO: save()
            _context.SaveChanges();
            ViewData["id"] = id;           
            
            return RedirectToAction("EventWindow", "Event" , ViewData);
        }

        public ActionResult SubmitData()
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
                if (date< DateTime.Now)
                {
                    return RedirectToAction("Error");
                }
                else {
                    _context.Add(eventToAdd);
                    _context.SaveChanges();
                }
                
                //return RedirectToAction(nameof(Index));
            }

            //return View(@event);

            return RedirectToAction("EventList", "Event");
        }

        public ActionResult submitChanges(string id)
        {
            //TODO: validate
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

            //TODO: updateEvent()
            Event tmp = _context.Events.Find(int.Parse(id));
            tmp.EventName = name;
            tmp.Type = game;
            tmp.StartTime = date.ToString();
            if (date < DateTime.Now)
            {
                return RedirectToAction("Error");
            }
            else
            {
                _context.Update(tmp);
                _context.SaveChanges();
            }
            return RedirectToAction("EventList");

            //return RedirectToAction("EventWindow", "Event", new { id });
        }

        public ActionResult SubmitParticipation(string id, string eventname)
        {
            ParticipantList temp = new ParticipantList();
            temp.EventId = int.Parse(id);
            temp.UserId = 1;
            List<ParticipantList> allData = _context.ParticipantLists.ToList();
            int index = allData.FindIndex(item => item.UserId == temp.UserId && item.EventId == temp.EventId);
            if (index < 0)
            {
                _context.Add(temp);
                _context.SaveChanges();
            }

            return RedirectToAction("EventWindow", "Event", new { id, eventname });
        }

        public ActionResult CancelParticipation(string id, string eventname)
        {
            ParticipantList temp = new ParticipantList();
            temp.EventId = int.Parse(id);
            temp.UserId = 1;
            List<ParticipantList> allData = _context.ParticipantLists.ToList();
            int index = allData.FindIndex(item => item.UserId == temp.UserId && item.EventId == temp.EventId);            
            if (index >= 0)
            {
                ParticipantList toDelete = allData[index];
                _context.Remove(toDelete);
                _context.SaveChanges();
            }
            ViewData["eventname"] = eventname;

            return RedirectToAction("EventWindow", "Event", new { id, eventname });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}