using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TravelAppAPI.Infrastructure;
using TravelAppAPI.Models;

namespace TravelAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly TravelAppContext _context;

        public PlacesController(TravelAppContext context)
        {
            _context = context;
        }

        // GET: api/Places
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Place>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
            var places = await _context.Places.ToListAsync();

            if (!places.Any())
            {
                return BadRequest("No places found");
            }

            return Ok(places);
        }

        // GET: api/Places/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Place), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Place>> GetPlace(int id)
        {
            var place = await _context.Places.FindAsync(id);

            if (place == null)
            {
                return NotFound();
            }

            return place;
        }

        // PUT: api/Places/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> PutPlace(int id, [FromBody]Place place)
        {
            if (id != place.Id)
            {
                return BadRequest();
            }

            var placeToUpdate = await _context.Places.SingleOrDefaultAsync(p => p.Id == place.Id);

            if (placeToUpdate == null)
            {
                return NotFound();
            }

            placeToUpdate.Address = place.Address;
            placeToUpdate.Name = place.Name;
            placeToUpdate.Latitude = place.Latitude;
            placeToUpdate.Longtitude = place.Longtitude;

            _context.Places.Update(placeToUpdate);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Places
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<Place>> PostPlace([FromBody]Place placeToAdd)
        {
            var place = new Place
            {
                Id = placeToAdd.Id,
                Address = placeToAdd.Address,
                Name = placeToAdd.Name,
                Latitude = placeToAdd.Latitude,
                Longtitude = placeToAdd.Longtitude
            };

            _context.Places.Add(place);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlace", new { id = place.Id }, place);
        }

        // DELETE: api/Places/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Place>> DeletePlace(int id)
        {
            var place = _context.Places.SingleOrDefault(p => p.Id == id);

            if (place == null)
            {
                return NotFound();
            }

            _context.Places.Remove(place);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
