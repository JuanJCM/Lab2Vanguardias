using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Entities;
using TicketSeller.Core.Interfaces;
namespace TicketSeller.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventrepository;
        public EventService(IRepository<Event> eventRepository)
        {
            _eventrepository = eventRepository;

        }
        public ServiceResult<Event> CreateEvent(Event entity)
        {
            var event = _eventrepository.Get(entity.Id);
            if(event == null)
            {
            return ServiceResult<Event>.ErrorResult($"Ya existe un evento con el id {entity.Id}");
            }
            return ServiceResult<Event>.SuccessfulResult(event);
        }

        public ServiceResult<Event> GetEventById(int id)
        {
            var event = _eventrepository.Get(id);
            if(event == null)
            {
            return ServiceResult<Event>.NotFoundResult($"No se encontro eveneto con el id {id}");
            }
            return ServiceResult<Event>.SuccessResult(event);
        }

        public ServiceResult<IReadOnlyList<Event>> GetEvents()
        {
            var event = _eventrepository.Get();
            return ServiceResult<IReadOnlyList<Event>>.SuccessResult(event);
        }

    }
}
