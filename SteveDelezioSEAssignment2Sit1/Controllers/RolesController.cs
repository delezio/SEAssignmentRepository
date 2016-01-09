using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SteveDelezioSEAssignment2Sit1.Models;

namespace SteveDelezioSEAssignment2Sit1.Controllers
{
    public class RolesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.tbl_Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Roles tbl_Roles = db.tbl_Roles.Find(id);
            if (tbl_Roles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Roles);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,RoleName")] tbl_Roles tbl_Roles)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Roles.Add(tbl_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Roles);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Roles tbl_Roles = db.tbl_Roles.Find(id);
            if (tbl_Roles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Roles);
        }


        public void UpdateRole(tbl_Roles tbl_Roles)
        {
            db.Entry(tbl_Roles).State = EntityState.Modified;
            db.SaveChanges();
        }
        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,RoleName")] tbl_Roles tbl_Roles)
        {
            if (ModelState.IsValid)
            {
              UpdateRole(tbl_Roles);
                return RedirectToAction("Index");
            }
            return View(tbl_Roles);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Roles tbl_Roles = db.tbl_Roles.Find(id);
            if (tbl_Roles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Roles tbl_Roles = db.tbl_Roles.Find(id);
            db.tbl_Roles.Remove(tbl_Roles);
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
