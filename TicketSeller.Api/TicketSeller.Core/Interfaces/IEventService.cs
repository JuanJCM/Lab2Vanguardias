using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Entities;

namespace TicketSeller.Core.Interfaces
{
    public interface IEventService
    {
        ServiceResult<IReadOnlyList<Event>> GetEvents();
        ServiceResult<IReadOnlyList<Event>> GetEventsByCategoryId(int id);
        ServiceResult<Event> GetEventById(int id);
        ServiceResult<Event> CreateEvent(Event entity);
        ServiceResult<Event> DeleteEvent(int id);
    }
}
