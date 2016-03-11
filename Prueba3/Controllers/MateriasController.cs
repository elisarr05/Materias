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
using Prueba3.Models;

namespace Prueba3.Controllers
{
    public class MateriasController : ApiController
    {
        private MateriasContext db = new MateriasContext();

        // GET api/Materias
        public IQueryable<Materias> GetMaterias()
        {
            return db.Materias;
        }

        // GET api/Materias/5
        [ResponseType(typeof(Materias))]
        public IHttpActionResult GetMaterias(int id)
        {
            Materias materias = db.Materias.Find(id);
            if (materias == null)
            {
                return NotFound();
            }

            return Ok(materias);
        }

        // PUT api/Materias/5
        public IHttpActionResult PutMaterias(int id, Materias materias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materias.id)
            {
                return BadRequest();
            }

            db.Entry(materias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriasExists(id))
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

        // POST api/Materias
        [ResponseType(typeof(Materias))]
        public IHttpActionResult PostMaterias(Materias materias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materias.Add(materias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materias.id }, materias);
        }

        // DELETE api/Materias/5
        [ResponseType(typeof(Materias))]
        public IHttpActionResult DeleteMaterias(int id)
        {
            Materias materias = db.Materias.Find(id);
            if (materias == null)
            {
                return NotFound();
            }

            db.Materias.Remove(materias);
            db.SaveChanges();

            return Ok(materias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MateriasExists(int id)
        {
            return db.Materias.Count(e => e.id == id) > 0;
        }
    }
}