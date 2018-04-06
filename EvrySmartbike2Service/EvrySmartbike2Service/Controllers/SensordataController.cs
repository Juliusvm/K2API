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
    public class SensordataController : ApiController
    {
        private EvrySmartbike2ServiceContext db = new EvrySmartbike2ServiceContext();

        // GET: api/Sensordata
        public IQueryable<Sensordata> GetSensordata()
        {
            return db.Sensordata;

        }



        // GET: api/Sensordata/5
        [ResponseType(typeof(Sensordata))]
        public async Task<IHttpActionResult> GetSensordata(Guid id)
        {
            Sensordata sensordata = await db.Sensordata.FindAsync(id);
            if (sensordata == null)
            {
                return NotFound();
            }

            return Ok(sensordata);
        }

        
        // POST: api/Sensordata
        [ResponseType(typeof(Sensordata))]
        public async Task<IHttpActionResult> PostSensordata(Sensordata sensordata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sensordata.Add(sensordata);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SensordataExists(sensordata.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sensordata.Id }, sensordata);
        }

        // DELETE: api/Sensordata/5
        [ResponseType(typeof(Sensordata))]
        public async Task<IHttpActionResult> DeleteSensordata(Guid id)
        {
            Sensordata sensordata = await db.Sensordata.FindAsync(id);
            if (sensordata == null)
            {
                return NotFound();
            }

            db.Sensordata.Remove(sensordata);
            await db.SaveChangesAsync();

            return Ok(sensordata);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SensordataExists(Guid id)
        {
            return db.Sensordata.Count(e => e.Id == id) > 0;
        }
    }
}