using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSeller.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }
        public Category Categoria { get; set; }
        public decimal Precio { get; set; }
    }
}
