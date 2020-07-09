using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        private EventDbContext context;
        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //List<Event> events = new List<Event>(EventData.GetAll());  ---> Before
            List<Event> events = context.Events.ToList(); // ----> after, casting the context.Events to a list


            return View(events);
        }

        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        [Route("Events/Add")]
        public IActionResult NewEvent(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Type = addEventViewModel.Type
                };

                //EventData.Add(newEvent); ---> Before
                context.Events.Add(newEvent); //----> new add using the context.Event
                context.SaveChanges();

                return Redirect("/Events");
            }

            return View("Add", addEventViewModel);
        }

        public IActionResult Delete()
        {
            //ViewBag.title = "Delete Events";
            //ViewBag.events = EventData.GetAll(); ---> Before
            ViewBag.events = context.Events.ToList(); //---> casting to list

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                //EventData.Remove(eventId);
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }
            context.SaveChanges();

            return Redirect("/Events");
        }
    }
}
