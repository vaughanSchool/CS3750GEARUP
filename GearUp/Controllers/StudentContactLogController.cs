using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GearUp.Models;

namespace GearUp.Controllers
{
    public class StudentContactLogController : Controller
    {
        private GearUpDBEntities db = new GearUpDBEntities();

        // GET: StudentContactLog
        public ActionResult Index()
        {
            var contacts = db.Contacts.Include(c => c.Service).Include(c => c.Student).Include(c => c.ParentServiceCode).Include(c => c.ServiceMethod);
            return View(contacts.ToList());
        }

        // GET: StudentContactLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: StudentContactLog/Create
        public ActionResult Create(int studentID)
        {
            ViewBag.serviceCode = new SelectList(db.ServiceCodes, "serviceCodeID", "serviceCode" );
            ViewBag.serviceID = new SelectList(db.Services, "serviceID", "serviceName");
            ViewBag.parentServiceID = new SelectList(db.ParentServiceCodes, "parentServiceID", "serviceCode");
            ViewBag.serviceMethodID = new SelectList(db.ServiceMethods, "serviceMethodID", "serviceMethodName");
            var log = new Contact();
            log.Student = db.Students.Find(studentID);
            return View(log);
        }

        // POST: StudentContactLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "studentID,serviceID,serviceDate,serviceMinutes,parentName,serviceMethodID,AspNetUser,schoolID,parentServiceID,contactNotes")] Contact contact, string serviceCode)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.serviceID = new SelectList(db.Services, "serviceID", "serviceName", contact.serviceID);
            ViewBag.studentID = new SelectList(db.Students, "studentID", "aspNetUserId", contact.studentID);
            ViewBag.parentServiceID = new SelectList(db.ParentServiceCodes, "parentServiceID", "serviceCode", contact.parentServiceID);
            ViewBag.serviceMethodID = new SelectList(db.ServiceMethods, "serviceMethodID", "serviceMethodName", contact.serviceMethodID);
            return View(contact);
        }

        // GET: StudentContactLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.serviceID = new SelectList(db.Services, "serviceID", "serviceName", contact.serviceID);
            ViewBag.studentID = new SelectList(db.Students, "studentID", "aspNetUserId", contact.studentID);
            ViewBag.parentServiceID = new SelectList(db.ParentServiceCodes, "parentServiceID", "serviceCode", contact.parentServiceID);
            ViewBag.serviceMethodID = new SelectList(db.ServiceMethods, "serviceMethodID", "serviceMethodName", contact.serviceMethodID);
            return View(contact);
        }

        // POST: StudentContactLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "contactID,studentID,serviceID,serviceDate,serviceMinutes,parentName,serviceMethodID,AspNetUser,schoolID,parentServiceID,contactNotes")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.serviceID = new SelectList(db.Services, "serviceID", "serviceName", contact.serviceID);
            ViewBag.studentID = new SelectList(db.Students, "studentID", "aspNetUserId", contact.studentID);
            ViewBag.parentServiceID = new SelectList(db.ParentServiceCodes, "parentServiceID", "serviceCode", contact.parentServiceID);
            ViewBag.serviceMethodID = new SelectList(db.ServiceMethods, "serviceMethodID", "serviceMethodName", contact.serviceMethodID);
            return View(contact);
        }

        // GET: StudentContactLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: StudentContactLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
