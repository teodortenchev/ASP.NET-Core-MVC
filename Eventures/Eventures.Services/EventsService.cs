using Eventures.Data;
using Eventures.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventures.Services
{
    public class EventsService : IEventsService
    {
        private readonly EventuresDbContext db;

        public EventsService(EventuresDbContext db)
        {
            this.db = db;
        }

        public void CreateEvent(string name, string place, DateTime startTime, DateTime endTime, int totalTickets, decimal pricePerTicket)
        {            
            Event @event = new Event
            {
                Name = name,
                Place = place,
                Start = startTime,
                End = endTime,
                TotalTickets = totalTickets,
                TicketPrice = pricePerTicket
            };

            db.Events.Add(@event);
            db.SaveChanges();
        }

        public ICollection<Event> GetAllEvents()
        {
            return db.Events.ToList();
        }
    }
}
