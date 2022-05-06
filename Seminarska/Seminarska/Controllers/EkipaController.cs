using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seminarska.Data;
using Seminarska.Models;

namespace Seminarska.Controllers
{
    public class EkipaController : Controller
    {
        private SeminarskaContext db = new SeminarskaContext();

        // GET: Ekipa
        public ActionResult Index()
        {
            var ekipas = db.Ekipas.Include(e => e.Turnir);
            return View(ekipas.ToList());
        }

        // GET: Ekipa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekipa ekipa = db.Ekipas.Find(id);
            if (ekipa == null)
            {
                return HttpNotFound();
            }
            return View(ekipa);
        }

        // GET: Ekipa/Create
        public ActionResult Create()
        {
            ViewBag.TurnirId = new SelectList(db.Turnirs, "Id", "TurnirIme");
            return View();
        }

        // POST: Ekipa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EkipaIme,EkipaSponsor,TurnirId")] Ekipa ekipa)
        {
            if (ModelState.IsValid)
            {
                db.Ekipas.Add(ekipa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TurnirId = new SelectList(db.Turnirs, "Id", "TurnirIme", ekipa.TurnirId);
            return View(ekipa);
        }

        // GET: Ekipa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekipa ekipa = db.Ekipas.Find(id);
            if (ekipa == null)
            {
                return HttpNotFound();
            }
            ViewBag.TurnirId = new SelectList(db.Turnirs, "Id", "TurnirIme", ekipa.TurnirId);
            return View(ekipa);
        }

        // POST: Ekipa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EkipaIme,EkipaSponsor,TurnirId")] Ekipa ekipa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ekipa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TurnirId = new SelectList(db.Turnirs, "Id", "TurnirIme", ekipa.TurnirId);
            return View(ekipa);
        }

        // GET: Ekipa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekipa ekipa = db.Ekipas.Find(id);
            if (ekipa == null)
            {
                return HttpNotFound();
            }
            return View(ekipa);
        }

        // POST: Ekipa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ekipa ekipa = db.Ekipas.Find(id);
            db.Ekipas.Remove(ekipa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
