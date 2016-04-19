using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GearUp.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace GearUp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private AdminEntities db = new AdminEntities();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.AspNetUsers.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {

            ViewBag.RolesId = new SelectList(db.AspNetRoles, "Id", "Name");
                
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Email,PasswordHash,UserName,FirstName,LastName")] AspNetUser aspNetUser, String RolesId)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = aspNetUser.UserName, Email = aspNetUser.Email};
               
                var result = await UserManager.CreateAsync(user, aspNetUser.PasswordHash);
                if(result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, RolesId);
                    return RedirectToAction("Index");
                }
               
            }

            return View(aspNetUser);
        }

        // GET: Admin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Include(a=> a.AspNetRoles).Where(a=> a.Id == id).ToList()[0];
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }

            ViewBag.RolesId = new SelectList(db.AspNetRoles, "Id", "Name", aspNetUser.AspNetRoles.ToList()[0]);

            return View(aspNetUser);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,FirstName,LastName")] AspNetUser aspNetUser, String RolesId)
        {
            if (ModelState.IsValid)
            {
                UserManager.AddToRole(aspNetUser.Id, RolesId);
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetUser);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUser);
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
