using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EvrySmartbike2Service.Models;
namespace EvrySmartbike2Service.Controllers
{
    public class BicycleTourController : ApiController
    {
        private EvrySmartbike2ServiceContext db = new EvrySmartbike2ServiceContext();

        // GET: api/BicycleTour
        public IQueryable<BicycleTour> GetBicycleTour()
        {
            return db.BicycleTours;
        }

        // GET: api/BicycleTour/5
        [ResponseType(typeof(BicycleTour))]
        public async Task<IHttpActionResult> GetBicycleTour(Guid id)
        {
            BicycleTour bicycleTour = await db.BicycleTours.FindAsync(id);
            if (bicycleTour == null)
            {
                return NotFound();
            }

            return Ok(bicycleTour);
        }

        // POST: api/BicycleTour
        [ResponseType(typeof(BicycleTour))]
        public async Task<IHttpActionResult> PostBicycleTour(BicycleTour bicycleTour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BicycleTours.Add(bicycleTour);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BicycleTourExists(bicycleTour.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bicycleTour.ID }, bicycleTour);
        }


        // DELETE: api/BicycleTour/5kjs-82da-kij3-kas3
        [ResponseType(typeof(BicycleTour))]
        public async Task<IHttpActionResult> DeleteBicycleTour(Guid id)
        {
            BicycleTour bicycleTour = await db.BicycleTours.FindAsync(id);
            if (bicycleTour == null)
            {
                return NotFound();
            }

            db.BicycleTours.Remove(bicycleTour);
            await db.SaveChangesAsync();

            return Ok(bicycleTour);
        }


        private bool BicycleTourExists(Guid id)
        {
            return db.BicycleTours.Count(e => e.ID == id) > 0;
        }
    }
}
