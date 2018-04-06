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

        // GET: api/Beacon
        public IQueryable<Sensor> GetSensordata()
        {
            return db.Sensors;
        }

        // POST: api/Sensordata
        [ResponseType(typeof(Sensor))]
        public async Task<IHttpActionResult> PostSensordata(Sensor sensor)
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

        private bool SensorExists(Guid id)
        {
            return db.Sensors.Count(e => e.SensorID == id) > 0;
        }


    }
}
