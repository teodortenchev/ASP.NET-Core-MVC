﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Models;
using Eventures.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        [Authorize]
        public ActionResult All()
        {
            var eventsViewModel = eventsService.GetAllEvents()
                .Select(x => new EventViewModel {
                    Id = x.Id,
                    Name = x.Name,
                    Place  = x.Place,
                    Start = x.Start.ToString("dd-MMM-yyyy HH:MM:ss"),
                    End = x.End.ToString("dd-MMM-yyyy HH:MM:ss"),
                    TotalTickets = x.TotalTickets,
                    TicketPrice = x.TicketPrice 
                }).ToList();

            return View(eventsViewModel);
            
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(EventCreationBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            eventsService.CreateEvent(model.Name, model.Place, model.Start, model.End, model.TotalTickets, model.TicketPrice);

            return RedirectToAction(nameof(All));
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

       

    }
}