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
    public class EmployeeController : ApiController
    {
        private EvrySmartbike2ServiceContext db = new EvrySmartbike2ServiceContext();

        // GET: api/Employee
        public IQueryable<Employee> GetSensordata()
        {
            return db.Employees;
        }

        // POST: api/Employee
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostSensordata(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.EmployeeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeID }, employee);
        }

        private bool EmployeeExists(Guid id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }

    }
}
