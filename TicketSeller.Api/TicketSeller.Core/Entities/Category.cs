using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSeller.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
