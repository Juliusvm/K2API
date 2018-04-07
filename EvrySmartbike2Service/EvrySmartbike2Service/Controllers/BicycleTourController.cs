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
        public IQueryable<BicycleTour> GetSensordata()
        {
            return db.BicycleTours;
        }

        // POST: api/BicycleTour
        [ResponseType(typeof(BicycleTour))]
        public async Task<IHttpActionResult> PostSensordata(BicycleTour bicycleTour)
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

        private bool BicycleTourExists(Guid id)
        {
            return db.BicycleTours.Count(e => e.ID == id) > 0;
        }
    }
}
