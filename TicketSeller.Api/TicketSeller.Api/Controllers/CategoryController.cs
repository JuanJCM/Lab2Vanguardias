using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSeller.Core.Interfaces;

namespace TicketSeller.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriaService categoriaService;

        public CategoryController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() 
        {
            var result = this.categoriaService.GetCategories();
            return this.Ok(result);
        }
    }
}
