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
using MvcApiFrameworkSteven;

namespace MvcApiFrameworkSteven.Controllers
{
    public class empleadoactividadsController : ApiController
    {
        private PruebaStevenEntities db = new PruebaStevenEntities();

        // GET: api/empleadoactividads
        public IQueryable<empleadoactividad> Getempleadoactividad()
        {
            return db.empleadoactividad;
        }

        // GET: api/empleadoactividads/5
        [ResponseType(typeof(empleadoactividad))]
        public IHttpActionResult Getempleadoactividad(int id)
        {
            empleadoactividad empleadoactividad = db.empleadoactividad.Find(id);
            if (empleadoactividad == null)
            {
                return NotFound();
            }

            return Ok(empleadoactividad);
        }

        // PUT: api/empleadoactividads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putempleadoactividad(int id, empleadoactividad empleadoactividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleadoactividad.idEmpActivid)
            {
                return BadRequest();
            }

            db.Entry(empleadoactividad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!empleadoactividadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/empleadoactividads
        [ResponseType(typeof(empleadoactividad))]
        public IHttpActionResult Postempleadoactividad(empleadoactividad empleadoactividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.empleadoactividad.Add(empleadoactividad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleadoactividad.idEmpActivid }, empleadoactividad);
        }

        // DELETE: api/empleadoactividads/5
        [ResponseType(typeof(empleadoactividad))]
        public IHttpActionResult Deleteempleadoactividad(int id)
        {
            empleadoactividad empleadoactividad = db.empleadoactividad.Find(id);
            if (empleadoactividad == null)
            {
                return NotFound();
            }

            db.empleadoactividad.Remove(empleadoactividad);
            db.SaveChanges();

            return Ok(empleadoactividad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool empleadoactividadExists(int id)
        {
            return db.empleadoactividad.Count(e => e.idEmpActivid == id) > 0;
        }
    }
}