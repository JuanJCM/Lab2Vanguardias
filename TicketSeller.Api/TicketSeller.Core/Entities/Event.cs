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

        public int IdCategoria { get; set; }
        public Category Categoria { get; set; }
        public decimal Precio { get; set; }

        public ICollection<Carrito> Events { get; set; } = new HashSet<Carrito>();
    }
}
