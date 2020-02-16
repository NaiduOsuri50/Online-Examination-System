using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aspire1.Models;

namespace aspire1.Controllers
{
    public class StudentsDetailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: StudentsDetails
        public ActionResult Index()
        {
            var studentsDetails = db.StudentsDetails.Include(s => s.BatchDetail).Include(s => s.BatchDetail1);
            return View(studentsDetails.ToList());
        }

        // GET: StudentsDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsDetail studentsDetail = db.StudentsDetails.Find(id);
            if (studentsDetail == null)
            {
                return HttpNotFound();
            }
            return View(studentsDetail);
        }

        // GET: StudentsDetails/Create
        public ActionResult Create()
        {
            ViewBag.StudentsBatchId = new SelectList(db.BatchDetails, "StudentsBatchId", "StudentsBatchName");
            ViewBag.StudentsBatchId = new SelectList(db.BatchDetails, "StudentsBatchId", "StudentsBatchName");
            return View();
        }

        // POST: StudentsDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentsId,StudentsName,EmailId,Contact,YearOfPassing,Gender,StudentsCategory,StudentsBatchId,LastModifiedDate,LastModifiedBy,CreatedDate,CreatedBy")] StudentsDetail studentsDetail)
        {
            if (ModelState.IsValid)
            {
                db.StudentsDetails.Add(studentsDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentsBatchId = new SelectList(db.BatchDetails, "StudentsBatchId", "StudentsBatchName", studentsDetail.StudentsBatchId);
            ViewBag.StudentsBatchId = new SelectList(db.BatchDetails, "StudentsBatchId", "StudentsBatchName", studentsDetail.StudentsBatchId);
            return View(studentsDetail);
        }

        // GET: StudentsDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsDetail studentsDetail = db.StudentsDetails.Find(id);
            if (studentsDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentsBatchId = new SelectList(db.BatchDetails, "StudentsBatchId", "StudentsBatchName", studentsDetail.StudentsBatchId);
            ViewBag.StudentsBatchId = new SelectList(db.BatchDetails, "StudentsBatchId", "StudentsBatchName", studentsDetail.StudentsBatchId);
            return View(studentsDetail);
        }

        // POST: StudentsDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentsId,StudentsName,EmailId,Contact,YearOfPassing,Gender,StudentsCategory,StudentsBatchId,LastModifiedDate,LastModifiedBy,CreatedDate,CreatedBy")] StudentsDetail studentsDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentsBatchId = new SelectList(db.BatchDetails, "StudentsBatchId", "StudentsBatchName", studentsDetail.StudentsBatchId);
            ViewBag.StudentsBatchId = new SelectList(db.BatchDetails, "StudentsBatchId", "StudentsBatchName", studentsDetail.StudentsBatchId);
            return View(studentsDetail);
        }

        // GET: StudentsDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsDetail studentsDetail = db.StudentsDetails.Find(id);
            if (studentsDetail == null)
            {
                return HttpNotFound();
            }
            return View(studentsDetail);
        }

        // POST: StudentsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsDetail studentsDetail = db.StudentsDetails.Find(id);
            db.StudentsDetails.Remove(studentsDetail);
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
