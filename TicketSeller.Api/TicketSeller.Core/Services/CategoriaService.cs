using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Entities;
using TicketSeller.Core.Interfaces;

namespace TicketSeller.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepository<Category> repository;

        public CategoriaService(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        public ServiceResult<IReadOnlyList<Category>> GetCategories()
        {
            var cat = repository.Get();
            return ServiceResult<IReadOnlyList<Category>>.SuccessResult(cat);
        }
    }
}
