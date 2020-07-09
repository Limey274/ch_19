using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {

        private EventDbContext context;
        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }


        //[HttpGet("EventCategory/Index")]
        public IActionResult Index()
        {
            List<EventCategory> Categories = context.Categories.ToList();
            return View(Categories);
        }
        //GET: 
        public IActionResult Create()
        {
            AddEventCategoryViewModel viewModel = new AddEventCategoryViewModel();

            return View(viewModel);
        }

        [HttpPost("/EventCategory/Create")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                EventCategory eventCategory = new EventCategory
                {
                    Name = viewModel.Name

                };
                context.Categories.Add(eventCategory);
                context.SaveChanges();
                
                return Redirect("/EventCategory");

            }
            return View("Create", viewModel);


        }
    }
}




