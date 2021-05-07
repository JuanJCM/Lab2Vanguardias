using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSeller.Api.Models
{
    public class CarritoDto
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public int CantidadBoletos { get; set; }
    }
}
