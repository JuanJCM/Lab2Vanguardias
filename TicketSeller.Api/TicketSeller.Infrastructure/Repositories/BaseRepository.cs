using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Interfaces;
using TicketSeller.Infrastructure.Context;

namespace TicketSeller.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    {
        private readonly TicketSellerDbContext _context;
        public TEntity Create(TEntity entity)
        {
            _context.AddAsync(entity);
            _context.SaveChangesAsync();
            return entity;
        }

        public abstract IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate);

        public abstract IReadOnlyList<TEntity> Get();

        public abstract TEntity Get(int id);

    }
}
