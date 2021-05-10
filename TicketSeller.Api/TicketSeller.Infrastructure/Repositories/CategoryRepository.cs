using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketSeller.Core.Entities;
using TicketSeller.Infrastructure.Context;

namespace TicketSeller.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        private readonly TicketSellerDbContext _context;

        public CategoryRepository(TicketSellerDbContext context)
        :base(context)
        {
            _context = context;
        }
        public override IReadOnlyList<Category> Filter(Func<Category, bool> predicate)
        {
            return _context.Categories.Where(predicate).ToList();
        }

        public override IReadOnlyList<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public override Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

    }
}
