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
    [Authorize(Roles = "MediaManager,Writer")]
    public class StateWorkflowsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: StateWorkflows
        [Authorize(Roles = "MediaManager,Writer")]
        public ActionResult Index()
        {
            tbl_Users u = db.tbl_Users.SingleOrDefault(x => x.Username == HttpContext.User.Identity.Name);
            var tbl_StateWorkflows = db.tbl_StateWorkflows.Include(t => t.tbl_ArticleStates).Include(t => t.tbl_Users).Where(x => x.UserId == u.UserId);
            return View(tbl_StateWorkflows.ToList());
        }

        // GET: StateWorkflows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_StateWorkflows tbl_StateWorkflows = db.tbl_StateWorkflows.Find(id);
            if (tbl_StateWorkflows == null)
            {
                return HttpNotFound();
            }
            return View(tbl_StateWorkflows);
        }

        // GET: StateWorkflows/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.tbl_ArticleStates, "StateId", "StateName");
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username");
            return View();
        }

        // POST: StateWorkflows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorflowPositionId,UserId,StateId,StateWorkflow_Id")] tbl_StateWorkflows tbl_StateWorkflows)
        {
            if (ModelState.IsValid)
            {
                db.tbl_StateWorkflows.Add(tbl_StateWorkflows);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.tbl_ArticleStates, "StateId", "StateName", tbl_StateWorkflows.StateId);
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username", tbl_StateWorkflows.UserId);
            return View(tbl_StateWorkflows);
        }

        // GET: StateWorkflows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_StateWorkflows tbl_StateWorkflows = db.tbl_StateWorkflows.Find(id);
            if (tbl_StateWorkflows == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.tbl_ArticleStates, "StateId", "StateName", tbl_StateWorkflows.StateId);
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username", tbl_StateWorkflows.UserId);
            return View(tbl_StateWorkflows);
        }

        // POST: StateWorkflows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorflowPositionId,UserId,StateId,StateWorkflow_Id")] tbl_StateWorkflows tbl_StateWorkflows)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_StateWorkflows).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.tbl_ArticleStates, "StateId", "StateName", tbl_StateWorkflows.StateId);
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username", tbl_StateWorkflows.UserId);
            return View(tbl_StateWorkflows);
        }

        // GET: StateWorkflows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_StateWorkflows tbl_StateWorkflows = db.tbl_StateWorkflows.Find(id);
            if (tbl_StateWorkflows == null)
            {
                return HttpNotFound();
            }
            return View(tbl_StateWorkflows);
        }

        // POST: StateWorkflows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_StateWorkflows tbl_StateWorkflows = db.tbl_StateWorkflows.Find(id);
            db.tbl_StateWorkflows.Remove(tbl_StateWorkflows);
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
