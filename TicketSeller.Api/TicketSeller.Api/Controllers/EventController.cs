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
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = this.eventService.GetEvents();
            return this.Ok(result);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            var result = this.eventService.GetEventsByCategoryId(id);
            if (result.Result == null)
            {
                return this.BadRequest(result.Error);
            }
            return this.Ok(result);
        }
        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = this.eventService.GetEventById(id);
            return this.Ok(result);
        }

        [HttpGet("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = this.eventService.DeleteEvent(id);
            if (result.Result == null)
            {
                return this.BadRequest(result.Error);
            }
            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event evnt)
        {
            var result = this.eventService.CreateEvent(evnt);
            if (result.Result == null)
            {
                return this.BadRequest(result.Error);
            }
            return this.Ok(result);
        }
    }
}