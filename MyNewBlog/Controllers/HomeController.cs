using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyNewBlog.Models;
using PagedList;

namespace MyNewBlog.Controllers
{
    public class HomeController : Controller
    {
        private NewsInformationEntities db = new NewsInformationEntities();

        //GET:Archives
        public ActionResult News(int? categoryId, int? page)
        {
            int pageSize = 12;

            if (page == 0)
            {
                page = 1;
            }
            int pageNumber = page ?? 1;
            ViewBag.categoryId = categoryId;
            if (categoryId > 0)
            {
                var articles = from a in db.Article
                               where a.categoryId == categoryId
                               select a;
                return View(articles.ToList().ToPagedList(pageNumber, pageSize));
            }
            return View(db.Article.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Home
        public ActionResult Index()
        {
            var category = from c in db.Category
                           select c;
            category = category.Where(c => c.id > 0 && c.id < 10);
            var categoryList = category.ToList();
            return View(categoryList);
        }

        public ActionResult About()
        {

            return View();
        }

        //GET: Aritlces
        public ActionResult Details(int? categoryId, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
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
