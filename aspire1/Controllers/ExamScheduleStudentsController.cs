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
    public class ExamScheduleStudentsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ExamScheduleStudents
        public ActionResult Index()
        {
            var examScheduleStudents = db.ExamScheduleStudents.Include(e => e.ExamSchedule).Include(e => e.StudentsDetail);
            return View(examScheduleStudents.ToList());
        }

        // GET: ExamScheduleStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamScheduleStudent examScheduleStudent = db.ExamScheduleStudents.Find(id);
            if (examScheduleStudent == null)
            {
                return HttpNotFound();
            }
            return View(examScheduleStudent);
        }

        // GET: ExamScheduleStudents/Create
        public ActionResult Create()
        {
            ViewBag.ExamScheduleId = new SelectList(db.ExamSchedules, "ExamScheduleId", "LastModifiedBy");
            ViewBag.StudentsId = new SelectList(db.StudentsDetails, "StudentsId", "StudentsName");
            return View();
        }

        // POST: ExamScheduleStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamScheduleStudentsId,ExamScheduleId,StudentsId,LastModifiedDate,LastModifiedBy,CreatedBy,CreatedDate")] ExamScheduleStudent examScheduleStudent)
        {
            if (ModelState.IsValid)
            {
                db.ExamScheduleStudents.Add(examScheduleStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExamScheduleId = new SelectList(db.ExamSchedules, "ExamScheduleId", "LastModifiedBy", examScheduleStudent.ExamScheduleId);
            ViewBag.StudentsId = new SelectList(db.StudentsDetails, "StudentsId", "StudentsName", examScheduleStudent.StudentsId);
            return View(examScheduleStudent);
        }

        // GET: ExamScheduleStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamScheduleStudent examScheduleStudent = db.ExamScheduleStudents.Find(id);
            if (examScheduleStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamScheduleId = new SelectList(db.ExamSchedules, "ExamScheduleId", "LastModifiedBy", examScheduleStudent.ExamScheduleId);
            ViewBag.StudentsId = new SelectList(db.StudentsDetails, "StudentsId", "StudentsName", examScheduleStudent.StudentsId);
            return View(examScheduleStudent);
        }

        // POST: ExamScheduleStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamScheduleStudentsId,ExamScheduleId,StudentsId,LastModifiedDate,LastModifiedBy,CreatedBy,CreatedDate")] ExamScheduleStudent examScheduleStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examScheduleStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamScheduleId = new SelectList(db.ExamSchedules, "ExamScheduleId", "LastModifiedBy", examScheduleStudent.ExamScheduleId);
            ViewBag.StudentsId = new SelectList(db.StudentsDetails, "StudentsId", "StudentsName", examScheduleStudent.StudentsId);
            return View(examScheduleStudent);
        }

        // GET: ExamScheduleStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamScheduleStudent examScheduleStudent = db.ExamScheduleStudents.Find(id);
            if (examScheduleStudent == null)
            {
                return HttpNotFound();
            }
            return View(examScheduleStudent);
        }

        // POST: ExamScheduleStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamScheduleStudent examScheduleStudent = db.ExamScheduleStudents.Find(id);
            db.ExamScheduleStudents.Remove(examScheduleStudent);
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
