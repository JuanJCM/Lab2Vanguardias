using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketSeller.Core.Entities;
using TicketSeller.Infrastructure.Context;

namespace TicketSeller.Infrastructure.Repositories
{
    public class EventRepository : BaseRepository<Event>
    {
        private readonly TicketSellerDbContext _context;

        public EventRepository(TicketSellerDbContext context)
        :base(context)
        {
            _context = context;
        }
        public override IReadOnlyList<Event> Filter(Func<Event, bool> predicate)
        {
            return _context.Events.Where(predicate).ToList();
        }

        public override IReadOnlyList<Event> Get()
        {
            return _context.Events.ToList();
        }

        public override Event Get(int id)
        {
            return _context.Events.FirstOrDefault(x => x.Id == id);
        }

    }
}
