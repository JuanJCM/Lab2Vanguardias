using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Entities;

namespace TicketSeller.Core.Interfaces
{
    public interface ICategoriaService
    {
        ServiceResult<IReadOnlyList<Category>> GetCategories();
    }
}
