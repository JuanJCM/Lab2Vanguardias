using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Entities;

namespace TicketSeller.Core.Interfaces
{
    interface ICarritoService
    {
        ServiceResult<Carrito> CreateCarrito(Carrito entity);
        ServiceResult<Carrito> Pagar(Carrito entity);
    }
}
