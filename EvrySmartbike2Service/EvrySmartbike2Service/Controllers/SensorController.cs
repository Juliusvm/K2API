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
    public class SensorController : ApiController
    {
        private EvrySmartbike2ServiceContext db = new EvrySmartbike2ServiceContext();

        // GET: api/Sensor
        public IQueryable<Sensor> GetSensors()
        {
            return db.Sensors;
        }

        // GET: api/Sensor/6870218c-e089-4236-93d7-f7938b5871af
        [ResponseType(typeof(Sensor))]
        public async Task<IHttpActionResult> GetSensor(Guid id)
        {
            Sensor sensor = await db.Sensors.FindAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }

            return Ok(sensor);
        }

        // POST: api/Sensor
        [ResponseType(typeof(Sensor))]
        public async Task<IHttpActionResult> PostSensor(Sensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sensors.Add(sensor);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SensorExists(sensor.SensorID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sensor.SensorID }, sensor);
        }


        // DELETE: api/Sensor/6870218c-e089-4236-93d7-f7938b5871af
        [ResponseType(typeof(Sensor))]
        public async Task<IHttpActionResult> DeleteSensor(Guid id)
        {
            Sensor sensor = await db.Sensors.FindAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }

            db.Sensors.Remove(sensor);

            await db.SaveChangesAsync();

            return Ok(sensor);
        }

        private bool SensorExists(String id)
        {
            return db.Sensors.Count(e => e.SensorID == id) > 0;
        }


    }
}
