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
    public class TurniraController : ApiController
    {
        private SeminarskaContext db = new SeminarskaContext();

        // GET: api/Turnira
        public IQueryable<Turnir> GetTurnirs()
        {
            return db.Turnirs;
        }

        // GET: api/Turnira/5
        [ResponseType(typeof(Turnir))]
        public IHttpActionResult GetTurnir(int id)
        {
            Turnir turnir = db.Turnirs.Find(id);
            if (turnir == null)
            {
                return NotFound();
            }

            return Ok(turnir);
        }

        // PUT: api/Turnira/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTurnir(int id, Turnir turnir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turnir.Id)
            {
                return BadRequest();
            }

            db.Entry(turnir).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnirExists(id))
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

        // POST: api/Turnira
        [ResponseType(typeof(Turnir))]
        public IHttpActionResult PostTurnir(Turnir turnir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Turnirs.Add(turnir);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = turnir.Id }, turnir);
        }

        // DELETE: api/Turnira/5
        [ResponseType(typeof(Turnir))]
        public IHttpActionResult DeleteTurnir(int id)
        {
            Turnir turnir = db.Turnirs.Find(id);
            if (turnir == null)
            {
                return NotFound();
            }

            db.Turnirs.Remove(turnir);
            db.SaveChanges();

            return Ok(turnir);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurnirExists(int id)
        {
            return db.Turnirs.Count(e => e.Id == id) > 0;
        }
    }
}