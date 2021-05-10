using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketSeller.Core.Entities;
using TicketSeller.Infrastructure.Context;

namespace TicketSeller.Infrastructure.Repositories
{
    public class CarritoRepository : BaseRepository<Carrito>
    {
        private readonly TicketSellerDbContext _context;

        public CarritoRepository(TicketSellerDbContext context)
        :base(context)
        {
            _context = context;
        }
        public override IReadOnlyList<Carrito> Filter(Func<Carrito, bool> predicate)
        {
            return _context.Carritos.Where(predicate).ToList();
        }

        public override IReadOnlyList<Carrito> Get()
        {
            return _context.Carritos.ToList();
        }

        public override Carrito Get(int id)
        {
            return _context.Carritos.FirstOrDefault(x => x.Id == id);
        }

    }
}
