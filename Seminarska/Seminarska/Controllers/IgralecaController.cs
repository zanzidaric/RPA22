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
    public class IgralecaController : ApiController
    {
        private SeminarskaContext db = new SeminarskaContext();

        // GET: api/Igraleca
        public IQueryable<Igralec> GetIgralecs()
        {
            return db.Igralecs;
        }

        // GET: api/Igraleca/5
        [ResponseType(typeof(Igralec))]
        public IHttpActionResult GetIgralec(int id)
        {
            Igralec igralec = db.Igralecs.Find(id);
            if (igralec == null)
            {
                return NotFound();
            }

            return Ok(igralec);
        }

        // PUT: api/Igraleca/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIgralec(int id, Igralec igralec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != igralec.Id)
            {
                return BadRequest();
            }

            db.Entry(igralec).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IgralecExists(id))
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

        // POST: api/Igraleca
        [ResponseType(typeof(Igralec))]
        public IHttpActionResult PostIgralec(Igralec igralec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Igralecs.Add(igralec);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = igralec.Id }, igralec);
        }

        // DELETE: api/Igraleca/5
        [ResponseType(typeof(Igralec))]
        public IHttpActionResult DeleteIgralec(int id)
        {
            Igralec igralec = db.Igralecs.Find(id);
            if (igralec == null)
            {
                return NotFound();
            }

            db.Igralecs.Remove(igralec);
            db.SaveChanges();

            return Ok(igralec);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IgralecExists(int id)
        {
            return db.Igralecs.Count(e => e.Id == id) > 0;
        }
    }
}