using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyNewBlog.App_Start;
using MyNewBlog.Models;
using PagedList;

namespace MyNewBlog.Controllers.Manage
{
    [LoginFilter]
    public class LinksController : Controller
    {
        private NewsInformationEntities db = new NewsInformationEntities();

        // GET: Links
        public ActionResult Index(int? page)
        {
            int pageSize = 13;

            if (page == 0)
            {
                page = 1;
            }
            int pageNumber = page ?? 1;
            var links = db.Link.ToList().ToPagedList(pageNumber, pageSize);
            ViewBag.Links = links;
            return View();
        }

        // GET: Links/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.Link.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            ViewBag.Link = link;
            return View();
        }

        // GET: Links/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Links/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,url,desc")] Link link)
        {
            if (ModelState.IsValid)
            {
                db.Link.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Link = link;
            return View();
        }

        // GET: Links/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.Link.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            ViewBag.Link = link;
            return View();
        }

        // POST: Links/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,url,desc")] Link link)
        {
            if (ModelState.IsValid)
            {
                db.Entry(link).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Link = link;
            return View();
        }

        // GET: Links/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.Link.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            ViewBag.Link = link;
            return View();
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Link link = db.Link.Find(id);
            db.Link.Remove(link);
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
