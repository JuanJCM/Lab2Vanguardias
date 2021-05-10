using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSeller.Core.Entities;
using TicketSeller.Core.Interfaces;

namespace TicketSeller.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            this.carritoService = carritoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Carrito carrito)
        {
            var result = this.carritoService.CreateCarrito(carrito);
            if (result.Result == null)
            {
                return this.BadRequest(result.Error);
            }
            return this.Ok(result);
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay()
        {
            var result = this.carritoService.Pagar();
            if (result.Result == null)
            {
                return this.BadRequest(result.Error);
            }
            var Detalles = result.Result.Select(d => new
            {
                Evento = d.Event?.Nombre,
                Cantidad = d.CantidadBoletos,
                Precio = d.Event?.Precio,
                Total = d.CantidadBoletos * d.Event?.Precio,
            });
            var model = new
            {
                Detalles = Detalles,
                Impuesto = Detalles.Sum(d => d.Total) * 15 / 100,
                Total = (Detalles.Sum(d => d.Total) * 15 / 100) + Detalles.Sum(d => d.Total),
            };

            return this.Ok(model);
        }
    }
}
