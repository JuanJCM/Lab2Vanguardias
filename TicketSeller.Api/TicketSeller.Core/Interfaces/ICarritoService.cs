using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Entities;

namespace TicketSeller.Core.Interfaces
{
    public interface ICarritoService
    {
        ServiceResult<Carrito> CreateCarrito(Carrito entity);
        ServiceResult<IReadOnlyList<Carrito>> Pagar();
    }
}
