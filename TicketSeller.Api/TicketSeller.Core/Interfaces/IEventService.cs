using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Entities;

namespace TicketSeller.Core.Interfaces
{
    public interface IEventService
    {
        ServiceResult<IReadOnlyList<Event>> GetEvents();
        ServiceResult<Event> GetEventById(int id);
        ServiceResult<Event> CreateEvent(EventArgs entity);
    }
}
