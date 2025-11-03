using Apex.Venues.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apex.Venues.Controllers
{
    [EnableCors("*")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypesController : ControllerBase
    {
        private readonly VenuesDbContext _context;

        public EventTypesController(VenuesDbContext context)
        {
            _context = context;
        }

        // GET: api/EventTypes
        [HttpGet]
        public async Task<IActionResult> GetEventTypes()
        {
            var dto = await _context.EventTypes
                                    .Select(e => new
                                    {
                                        e.Id,
                                        e.Title
                                    }).ToListAsync();
            return Ok(dto);
        }
    }
}
