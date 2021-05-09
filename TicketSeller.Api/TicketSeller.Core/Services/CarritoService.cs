using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Entities;
using TicketSeller.Core.Interfaces;

namespace TicketSeller.Core.Services
{
    class CarritoService : ICarritoService
    {
        public ServiceResult<Carrito> CreateCarrito(Carrito entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<Carrito> Pagar(Carrito entity)
        {
            throw new NotImplementedException();
        }
    }
}
