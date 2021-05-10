using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.Core.Interfaces;
using TicketSeller.Infrastructure.Context;

namespace TicketSeller.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    {
        private readonly TicketSellerDbContext _context;

        protected BaseRepository(TicketSellerDbContext context)
        {
            _context = context;
        }
        public virtual TEntity Update(TEntity entity)
        {
            var entry = this._context.Entry(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        public abstract IReadOnlyList<TEntity> Get();

        public abstract TEntity Get(int id);

        public TEntity Create(TEntity entity)
        {
            _context.AddAsync(entity);
            _context.SaveChangesAsync();
            return entity;
        }

        public abstract IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate);

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }
        public virtual TEntity Delete(TEntity entity)
        {
            var entry = this._context.Entry(entity);
            entry.State = EntityState.Deleted;
            return entity;
        }
    }
}