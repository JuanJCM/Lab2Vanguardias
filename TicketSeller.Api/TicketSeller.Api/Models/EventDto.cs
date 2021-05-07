using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSeller.Api.Models
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal Precio { get; set; }
    }
}
