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
    public class ExamScheduleQuestionsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ExamScheduleQuestions
        public ActionResult Index()
        {
            var examScheduleQuestions = db.ExamScheduleQuestions.Include(e => e.ExamSchedule).Include(e => e.Question);
            return View(examScheduleQuestions.ToList());
        }

        // GET: ExamScheduleQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamScheduleQuestion examScheduleQuestion = db.ExamScheduleQuestions.Find(id);
            if (examScheduleQuestion == null)
            {
                return HttpNotFound();
            }
            return View(examScheduleQuestion);
        }

        // GET: ExamScheduleQuestions/Create
        public ActionResult Create()
        {
            ViewBag.ExamScheduleId = new SelectList(db.ExamSchedules, "ExamScheduleId", "LastModifiedBy");
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Question1");
            return View();
        }

        // POST: ExamScheduleQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamScheduleQuestionsId,QuestionId,ExamScheduleId")] ExamScheduleQuestion examScheduleQuestion)
        {
            if (ModelState.IsValid)
            {
                db.ExamScheduleQuestions.Add(examScheduleQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExamScheduleId = new SelectList(db.ExamSchedules, "ExamScheduleId", "LastModifiedBy", examScheduleQuestion.ExamScheduleId);
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Question1", examScheduleQuestion.QuestionId);
            return View(examScheduleQuestion);
        }

        // GET: ExamScheduleQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamScheduleQuestion examScheduleQuestion = db.ExamScheduleQuestions.Find(id);
            if (examScheduleQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamScheduleId = new SelectList(db.ExamSchedules, "ExamScheduleId", "LastModifiedBy", examScheduleQuestion.ExamScheduleId);
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Question1", examScheduleQuestion.QuestionId);
            return View(examScheduleQuestion);
        }

        // POST: ExamScheduleQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamScheduleQuestionsId,QuestionId,ExamScheduleId")] ExamScheduleQuestion examScheduleQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examScheduleQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamScheduleId = new SelectList(db.ExamSchedules, "ExamScheduleId", "LastModifiedBy", examScheduleQuestion.ExamScheduleId);
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Question1", examScheduleQuestion.QuestionId);
            return View(examScheduleQuestion);
        }

        // GET: ExamScheduleQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamScheduleQuestion examScheduleQuestion = db.ExamScheduleQuestions.Find(id);
            if (examScheduleQuestion == null)
            {
                return HttpNotFound();
            }
            return View(examScheduleQuestion);
        }

        // POST: ExamScheduleQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamScheduleQuestion examScheduleQuestion = db.ExamScheduleQuestions.Find(id);
            db.ExamScheduleQuestions.Remove(examScheduleQuestion);
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
