using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSeller.Core.Entities
{
    public class Carrito
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public int CantidadBoletos { get; set; }
        public Event Event { get; set; }
    }
}
