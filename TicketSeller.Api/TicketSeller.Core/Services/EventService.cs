using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketSeller.Core.Entities;
using TicketSeller.Core.Interfaces;
namespace TicketSeller.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventrepository;
        private readonly IRepository<Category> categoryRepository;

        public EventService(IRepository<Event> eventRepository,
                        IRepository<Category> categoryRepository)
        {
            this._eventrepository = eventRepository;
            this.categoryRepository = categoryRepository;
        }
        public ServiceResult<Event> CreateEvent(Event entity)
        {
            var category = categoryRepository.Get(entity.IdCategoria);
            if (category == null)
            {
                return ServiceResult<Event>.ErrorResult($"No se encontro una categoría con el id [{entity.IdCategoria}]");
            }

            var all = _eventrepository.Filter(e => e.IdCategoria == entity.IdCategoria);
            if (all.Count >= 2)
            {
                return ServiceResult<Event>.ErrorResult($"Ya no hay más espacio para esta categoría");
            }

            var events = _eventrepository.Filter(e => e.Nombre == entity.Nombre);
            if (events != null)
            {
                return ServiceResult<Event>.ErrorResult($"Ya existe un evento con el nombre {entity.Nombre}");
            }

            _eventrepository.Create(entity);
            _eventrepository.SaveChanges();
            return ServiceResult<Event>.SuccessResult(entity);
        }

        public ServiceResult<Event> DeleteEvent(int id)
        {
            var evnt = _eventrepository.Get(id);
            if (evnt == null)
            {
                return ServiceResult<Event>.ErrorResult($"No existe un evento con el id [{id}]");
            }

            _eventrepository.Delete(evnt);
            _eventrepository.SaveChanges();
            return ServiceResult<Event>.SuccessResult(evnt);
        }

        public ServiceResult<Event> GetEventById(int id)
        {
            var evnt = _eventrepository.Get(id);
            if (evnt == null)
            {
                return ServiceResult<Event>.ErrorResult($"No existe un evento con el id [{id}]");
            }
            return ServiceResult<Event>.SuccessResult(evnt);
        }

        public ServiceResult<IReadOnlyList<Event>> GetEvents()
        {
            var evnt = _eventrepository.Get();
            return ServiceResult<IReadOnlyList<Event>>.SuccessResult(evnt);
        }

        public ServiceResult<IReadOnlyList<Event>> GetEventsByCategoryId(int id)
        {
            var evnt = _eventrepository.Filter(e => e.IdCategoria == id);
            return ServiceResult<IReadOnlyList<Event>>.SuccessResult(evnt);
        }
    }
}