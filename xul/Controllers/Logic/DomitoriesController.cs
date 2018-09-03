using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Xul.Domain.Entities;

namespace xul.Controllers.Logic
{
    public class DomitoriesController : Controller
    {
        private EntitiesContainer db = new EntitiesContainer();

        // GET: Domitories
        public ActionResult Index()
        {
            var domitories = db.Domitories.Include(d => d.School);
            return View(domitories.ToList());
        }

        // GET: Domitories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domitory domitory = db.Domitories.Find(id);
            if (domitory == null)
            {
                return HttpNotFound();
            }
            return View(domitory);
        }

        // GET: Domitories/Create
        public ActionResult Create()
        {
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName");
            return View();
        }

        // POST: Domitories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DomitoryName,DomitoryNo,SchoolId")] Domitory domitory)
        {
            if (ModelState.IsValid)
            {
                db.Domitories.Add(domitory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", domitory.SchoolId);
            return View(domitory);
        }

        // GET: Domitories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domitory domitory = db.Domitories.Find(id);
            if (domitory == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", domitory.SchoolId);
            return View(domitory);
        }

        // POST: Domitories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DomitoryName,DomitoryNo,SchoolId")] Domitory domitory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(domitory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", domitory.SchoolId);
            return View(domitory);
        }

        // GET: Domitories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Domitory domitory = db.Domitories.Find(id);
            if (domitory == null)
            {
                return HttpNotFound();
            }
            return View(domitory);
        }

        // POST: Domitories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Domitory domitory = db.Domitories.Find(id);
            db.Domitories.Remove(domitory);
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
