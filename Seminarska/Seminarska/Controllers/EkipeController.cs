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
using Seminarska.Data;
using Seminarska.Models;

namespace Seminarska.Controllers
{
    public class EkipeController : ApiController
    {
        private SeminarskaContext db = new SeminarskaContext();

        // GET: api/Ekipe
        public IQueryable<Ekipa> GetEkipas()
        {
            return db.Ekipas;
        }

        // GET: api/Ekipe/5
        [ResponseType(typeof(Ekipa))]
        public IHttpActionResult GetEkipa(int id)
        {
            Ekipa ekipa = db.Ekipas.Find(id);
            if (ekipa == null)
            {
                return NotFound();
            }

            return Ok(ekipa);
        }

        // PUT: api/Ekipe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEkipa(int id, Ekipa ekipa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ekipa.Id)
            {
                return BadRequest();
            }

            db.Entry(ekipa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EkipaExists(id))
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

        // POST: api/Ekipe
        [ResponseType(typeof(Ekipa))]
        public IHttpActionResult PostEkipa(Ekipa ekipa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ekipas.Add(ekipa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ekipa.Id }, ekipa);
        }

        // DELETE: api/Ekipe/5
        [ResponseType(typeof(Ekipa))]
        public IHttpActionResult DeleteEkipa(int id)
        {
            Ekipa ekipa = db.Ekipas.Find(id);
            if (ekipa == null)
            {
                return NotFound();
            }

            db.Ekipas.Remove(ekipa);
            db.SaveChanges();

            return Ok(ekipa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EkipaExists(int id)
        {
            return db.Ekipas.Count(e => e.Id == id) > 0;
        }
    }
}