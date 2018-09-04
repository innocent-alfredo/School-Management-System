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
    public class StudentController : Controller
    {
        private EntitiesContainer db = new EntitiesContainer();

        // GET: Student
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Class).Include(s => s.Parent);
            return View(students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Class klas = db.Classes.Find(id);
            if (klas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "ClassName");
            ViewBag.ParentId = new SelectList(db.Parents, "Id", "FirstName");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdmissionNo,SchoolId,ClassId,ParentId,FirstName,MiddleName,LastName,DateOfBirth,Gender,MaritalStatus,CreatedBy,CreatedDate,EditedBy,EditedDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "Id", "ClassName", student.ClassId);
            ViewBag.ParentId = new SelectList(db.Parents, "Id", "FirstName", student.ParentId);
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "ClassName", student.ClassId);
            ViewBag.ParentId = new SelectList(db.Parents, "Id", "FirstName", student.ParentId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdmissionNo,SchoolId,ClassId,ParentId,FirstName,MiddleName,LastName,DateOfBirth,Gender,MaritalStatus,CreatedBy,CreatedDate,EditedBy,EditedDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "ClassName", student.ClassId);
            ViewBag.ParentId = new SelectList(db.Parents, "Id", "FirstName", student.ParentId);
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
