using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Employee
        public IQueryable<newTblEmployee> GetnewTblEmployees()
        {
            return db.newTblEmployees;
        }

        //GET: api/Employee/5
        [ResponseType(typeof(newTblEmployee))]
        public IHttpActionResult GetnewTblEmployee(int id)
        {
            newTblEmployee newTblEmployee = db.newTblEmployees.Find(id);
            if (newTblEmployee == null)
            {
                return NotFound();
            }
            return Ok(newTblEmployee);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutnewTblEmployee(int id, newTblEmployee newTblEmployee)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != newTblEmployee.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(newTblEmployee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!newTblEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Employee
        [ResponseType(typeof(newTblEmployee))]
        public IHttpActionResult PostnewTblEmployee(newTblEmployee newTblEmployee)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            db.newTblEmployees.Add(newTblEmployee);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = newTblEmployee.EmployeeID }, newTblEmployee);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(newTblEmployee))]
        public IHttpActionResult DeletenewTblEmployee(int id)
        {
            newTblEmployee newTblEmployee = db.newTblEmployees.Find(id);
            if (newTblEmployee == null)
            {
                return NotFound();
            }

            db.newTblEmployees.Remove(newTblEmployee);
            db.SaveChanges();

            return Ok(newTblEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool newTblEmployeeExists(int id)
        {
            return db.newTblEmployees.Count(e => e.EmployeeID == id) > 0;
        }
    }
}