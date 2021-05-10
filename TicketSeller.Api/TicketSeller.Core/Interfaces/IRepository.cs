using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSeller.Core.Interfaces
{

    public interface IRepository<TEntity>
    {
        IReadOnlyList<TEntity> Get();

        TEntity Get(int id);
     
        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate);

        TEntity Delete(TEntity entity);

        int SaveChanges();
    }
}
