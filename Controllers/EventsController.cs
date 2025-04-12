using EventBookingAPI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var eventEntity = await _eventService.GetEventByIdAsync(id);
            return eventEntity == null ? NotFound() : Ok(eventEntity);
        }
    }
}
