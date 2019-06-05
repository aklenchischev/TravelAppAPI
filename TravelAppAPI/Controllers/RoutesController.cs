using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAppAPI.Infrastructure;
using TravelAppAPI.Models;
using System.Net;

namespace TravelAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly TravelAppContext _context;

        public RoutesController(TravelAppContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Route>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<Route>>> GetRoutes()
        {
            var routes = await _context.Routes
                .Include(r => r.RoutePlaces)
                    .ThenInclude(rp => rp.Place)
                .ToListAsync();

            if (!routes.Any())
            {
                return BadRequest("No routes found");
            }

            return Ok(routes);
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Route), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Route>> GetRoute(int id)
        {
            if (id < 0)
            {
                return BadRequest("Incorrect id format");
            }

            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        // PUT: api/Routes/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> PutRoute(int id, [FromBody]Route route)
        {
            if (id != route.Id)
            {
                return BadRequest();
            }

            var routeToUpdate = await _context.Routes.SingleOrDefaultAsync(r => r.Id == route.Id);

            if (routeToUpdate == null)
            {
                return NotFound();
            }

            routeToUpdate.Favourites = route.Favourites;
            routeToUpdate.Name = route.Name;
            routeToUpdate.RoutePlaces = route.RoutePlaces;

            _context.Routes.Update(routeToUpdate);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Routes
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<Route>> PostRoute([FromBody]Route routeToAdd)
        {
            var route = new Route
            {
                Id = routeToAdd.Id,
                Favourites = routeToAdd.Favourites,
                Name = routeToAdd.Name,
                RoutePlaces = routeToAdd.RoutePlaces
            };

            _context.Routes.Add(route);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoute", new { id = route.Id }, route);
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Route>> DeleteRoute(int id)
        {
            var route = _context.Routes.SingleOrDefault(r => r.Id == id);

            if (route == null)
            {
                return NotFound();
            }

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
