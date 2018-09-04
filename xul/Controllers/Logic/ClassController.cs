using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using xul.Models.ViewModel;
using Xul.Domain.Entities;

namespace xul.Controllers.Logic
{
    public class ClassController : Controller
    {
        private EntitiesContainer db = new EntitiesContainer();
        public JsonResult IsClass_Available(string ClassName)
        {
            return Json(!db.Classes.Any(g => g.ClassName == ClassName), JsonRequestBehavior.AllowGet);
        }

        // GET: Class
        public ActionResult Index()
        {
            var classes = db.Classes;
            return View(classes.ToList());
        }

        // GET: Class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Class/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName");
                return View();
            }

            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName",school.Id);
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassName,SchoolId")] ClassViewModel classViewModel )
        {
            if (ModelState.IsValid)
            {
                var klas = new  Class()
                {
                    //mapping
                    ClassName = classViewModel.ClassName,
                    SchoolId = classViewModel.SchoolId
                    
                };

                db.Classes.Add(klas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName",classViewModel.SchoolId);
            return View(classViewModel);
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", @class.SchoolId);
            return View(@class);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassName,SchoolId")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", @class.SchoolId);
            return View(@class);
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
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
