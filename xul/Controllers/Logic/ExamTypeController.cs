﻿using System;
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
    public class ExamTypeController : Controller
    {
        private EntitiesContainer db = new EntitiesContainer();

        // GET: ExamType
        public ActionResult Index()
        {
            return View(db.ExamTypes.ToList());
        }

        // GET: ExamType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamType examType = db.ExamTypes.Find(id);
            if (examType == null)
            {
                return HttpNotFound();
            }
            return View(examType);
        }

        // GET: ExamType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] ExamType examType)
        {
            if (ModelState.IsValid)
            {
                db.ExamTypes.Add(examType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examType);
        }

        // GET: ExamType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamType examType = db.ExamTypes.Find(id);
            if (examType == null)
            {
                return HttpNotFound();
            }
            return View(examType);
        }

        // POST: ExamType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] ExamType examType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examType);
        }

        // GET: ExamType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamType examType = db.ExamTypes.Find(id);
            if (examType == null)
            {
                return HttpNotFound();
            }
            return View(examType);
        }

        // POST: ExamType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamType examType = db.ExamTypes.Find(id);
            db.ExamTypes.Remove(examType);
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
