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
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        // GET: api/Employee/6870218c-e089-4236-93d7-f7938b5871af
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> GetEmployee(Guid id)
        {
            Employee employees = await db.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }
        // POST: api/Employee
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostEmployee(Employee employee)
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


        // DELETE: api/Employee/6870218c-e089-4236-93d7-f7938b5871af
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(Guid id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }

        private bool EmployeeExists(Guid id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }

    }
}
