using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using About_Myself.Models;

namespace About_Myself.Controllers
{
    public class AboutMyselfController : Controller
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: AboutMyself
        public ActionResult Index()
        {
            return View(db.Employeemvcs.ToList());
        }

        // GET: AboutMyself/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeemvc employeemvc = db.Employeemvcs.Find(id);
            if (employeemvc == null)
            {
                return HttpNotFound();
            }
            return View(employeemvc);
        }

        // GET: AboutMyself/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutMyself/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,Place,Aboutme")] Employeemvc employeemvc)
        {
            if (ModelState.IsValid)
            {
                db.Employeemvcs.Add(employeemvc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeemvc);
        }

        // GET: AboutMyself/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeemvc employeemvc = db.Employeemvcs.Find(id);
            if (employeemvc == null)
            {
                return HttpNotFound();
            }
            return View(employeemvc);
        }

        // POST: AboutMyself/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeName,Place,Aboutme")] Employeemvc employeemvc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeemvc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeemvc);
        }

        // GET: AboutMyself/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeemvc employeemvc = db.Employeemvcs.Find(id);
            if (employeemvc == null)
            {
                return HttpNotFound();
            }
            return View(employeemvc);
        }

        // POST: AboutMyself/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employeemvc employeemvc = db.Employeemvcs.Find(id);
            db.Employeemvcs.Remove(employeemvc);
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
