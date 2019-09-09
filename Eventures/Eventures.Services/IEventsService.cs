using Eventures.Domain;
using System;
using System.Collections.Generic;

namespace Eventures.Services
{
    public interface IEventsService
    {
        void CreateEvent(string name, string place, DateTime startTime, DateTime endTime, int totalTickets, decimal pricePerTicket);

        ICollection<Event> GetAllEvents();
    }
}
