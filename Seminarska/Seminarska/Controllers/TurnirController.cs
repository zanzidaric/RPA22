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
    public class TurnirController : Controller
    {
        private SeminarskaContext db = new SeminarskaContext();

        // GET: Turnir
        public ActionResult Index()
        {
            return View(db.Turnirs.ToList());
        }

        // GET: Turnir/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turnir turnir = db.Turnirs.Find(id);
            if (turnir == null)
            {
                return HttpNotFound();
            }
            return View(turnir);
        }

        // GET: Turnir/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Turnir/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TurnirIme,Datum")] Turnir turnir)
        {
            if (ModelState.IsValid)
            {
                db.Turnirs.Add(turnir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(turnir);
        }

        // GET: Turnir/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turnir turnir = db.Turnirs.Find(id);
            if (turnir == null)
            {
                return HttpNotFound();
            }
            return View(turnir);
        }

        // POST: Turnir/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TurnirIme,Datum")] Turnir turnir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turnir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turnir);
        }

        // GET: Turnir/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turnir turnir = db.Turnirs.Find(id);
            if (turnir == null)
            {
                return HttpNotFound();
            }
            return View(turnir);
        }

        // POST: Turnir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turnir turnir = db.Turnirs.Find(id);
            db.Turnirs.Remove(turnir);
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
