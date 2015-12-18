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
    public class ArticlesController : Controller
    {
        private DataContext db = new DataContext();
        MyService.ServiceManager ms = new MyService.ServiceManager();
        // GET: Articles
        public ActionResult Index()
        {
            var tbl_Articles = db.tbl_Articles.Include(t => t.tbl_Users).Include(t => t.tbl_ArticleStatuses);
            return View(tbl_Articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Articles tbl_Articles = db.tbl_Articles.Find(id);
            if (tbl_Articles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Articles);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username");
            ViewBag.ArticleStatusId = new SelectList(db.tbl_ArticleStatuses, "ArticleStatusId", "ArticleStatusName");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleId,ArticleTitle,ArticleContent,ArticleComments,ArticlePublishDateTime,UserId,ArticleMediaManagerId,ArticleStatusId")] tbl_Articles tbl_Articles)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Articles.Add(tbl_Articles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username", tbl_Articles.UserId);
            ViewBag.ArticleStatusId = new SelectList(db.tbl_ArticleStatuses, "ArticleStatusId", "ArticleStatusName", tbl_Articles.ArticleStatusId);
            return View(tbl_Articles);
        }
        public ActionResult CreateArticle()
        {
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username");
            ViewBag.MediaManagerId = new SelectList(db.tbl_Users.Where(x=>x.RoleId==2), "UserId", "Username");
            ViewBag.ArticleStatusId = new SelectList(db.tbl_ArticleStatuses, "ArticleStatusId", "ArticleStatusName");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArticle([Bind(Include = "ArticleId,ArticleTitle,ArticleContent,ArticleComments,ArticlePublishDateTime,UserId,ArticleMediaManagerId,ArticleStatusId")] tbl_Articles tbl_Articles)
        {
            if (ModelState.IsValid)
            {
                tbl_Articles.ArticleComments = "";
                tbl_Articles.UserId = db.tbl_Users.SingleOrDefault(x=>x.Username==HttpContext.User.Identity.Name).UserId;
                tbl_Articles.ArticleStateId = 1;
                tbl_Articles.ArticleStatusId = 5;
                ms.CreateArticle(tbl_Articles.ArticleTitle, tbl_Articles.ArticleContent, tbl_Articles.ArticleComments,
                    tbl_Articles.ArticlePublishDateTime, tbl_Articles.UserId, tbl_Articles.ArticleMediaManagerId,
                    tbl_Articles.ArticleStatusId, tbl_Articles.ArticleStateId);
               // db.tbl_Articles.Add(tbl_Articles);

              //  db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username", tbl_Articles.UserId);
            ViewBag.MediaManagerId = new SelectList(db.tbl_Users.Where(x => x.RoleId == 2), "UserId", "Username");
            ViewBag.ArticleStatusId = new SelectList(db.tbl_ArticleStatuses, "ArticleStatusId", "ArticleStatusName", tbl_Articles.ArticleStatusId);
            return View(tbl_Articles);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Articles tbl_Articles = db.tbl_Articles.Find(id);
            if (tbl_Articles == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username", tbl_Articles.UserId);
            ViewBag.ArticleStatusId = new SelectList(db.tbl_ArticleStatuses, "ArticleStatusId", "ArticleStatusName", tbl_Articles.ArticleStatusId);
            return View(tbl_Articles);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,ArticleTitle,ArticleContent,ArticleComments,ArticlePublishDateTime,UserId,ArticleMediaManagerId,ArticleStatusId")] tbl_Articles tbl_Articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.tbl_Users, "UserId", "Username", tbl_Articles.UserId);
            ViewBag.ArticleStatusId = new SelectList(db.tbl_ArticleStatuses, "ArticleStatusId", "ArticleStatusName", tbl_Articles.ArticleStatusId);
            return View(tbl_Articles);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Articles tbl_Articles = db.tbl_Articles.Find(id);
            if (tbl_Articles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Articles);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Articles tbl_Articles = db.tbl_Articles.Find(id);
            db.tbl_Articles.Remove(tbl_Articles);
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
