using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketSeller.Core.Entities;
using TicketSeller.Core.Interfaces;

namespace TicketSeller.Core.Services
{
    public class CarritoService : ICarritoService
    {
        private readonly IRepository<Carrito> carritoRepository;
        private readonly IRepository<Event> eventRepository;

        public CarritoService(IRepository<Carrito> carritoRepository,
            IRepository<Event> eventRepository)
        {
            this.carritoRepository = carritoRepository;
            this.eventRepository = eventRepository;
        }
        public ServiceResult<Carrito> CreateCarrito(Carrito entity)
        {
            if (entity.CantidadBoletos<=0)
            {
                return ServiceResult<Carrito>.ErrorResult($"La cantidad solicitada debe ser mayor a cero");
            }
            var events = eventRepository.Get(entity.IdEvento);
            if (events == null)
            {
                return ServiceResult<Carrito>.ErrorResult($"No se encontro un evento con el id [{entity.IdEvento}]");
            }
            if (events.CantidadDisponible < entity.CantidadBoletos)
            {
                return ServiceResult<Carrito>.ErrorResult($"La cantidad disponible supera a la solicitada. Disponible: [{events.CantidadDisponible}].");
            }
            events.CantidadDisponible -= entity.CantidadBoletos;
            eventRepository.Update(events);

            var exist = carritoRepository.Filter(c => c.IdEvento == entity.IdEvento).First();
            if (exist != null)
            {
                exist.CantidadBoletos += entity.CantidadBoletos;
                carritoRepository.Update(exist);
            }
            else
            {
                carritoRepository.Create(entity);
            }

            this.carritoRepository.SaveChanges();
            return ServiceResult<Carrito>.SuccessResult(entity);
        }

        public ServiceResult<IReadOnlyList<Carrito>> Pagar()
        {
            var exist = carritoRepository.Get();
            if (exist == null)
            {
                return ServiceResult<IReadOnlyList<Carrito>>.ErrorResult($"No se encontro elementos en el carrito");
            }
            var secundary = exist;
            for (int i = 0; i < secundary.Count; i++)
            {
                carritoRepository.Delete(exist[i]);
            }
            return ServiceResult<IReadOnlyList<Carrito>>.SuccessResult(secundary);
        }
    }
}
