using MyNewBlog.App_Start;
using MyNewBlog.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Web.Mvc;

namespace MyNewBlog.Controllers.Manage
{
    [LoginFilter]
    public class ArticlesController : Controller
    {

        private NewsInformationEntities db = new NewsInformationEntities();
        // GET: Article


        //GET: Articles
        public ActionResult Index(int? page)
        {
            int pageSize = 13;

            if (page == 0)
            {
                page = 1;
            }
            int pageNumber = page ?? 1;
            List<String> cateNames = new List<String>();
            var categories = db.Category.ToList();
            foreach(Category cate in categories)
            {
                cateNames.Add(cate.cateName);
            }      
            ViewBag.cateNames = cateNames;
            return View(db.Article.ToList().ToPagedList(pageNumber, pageSize));
        }



        // POST:  文章编辑

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Article article)
        {
            //int id,string title,string link,DateTime date,string description,string author

            System.Diagnostics.Debug.Write(article.author);
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return RedirectToAction("/Index");
        }



        //添加文章
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Article article)
        {
            //int id,string title,string link,DateTime date,string description,string author

            if (ModelState.IsValid)
            {
                db.Article.Add(article);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        //GET: Cates 模态框获取分类
        [HttpGet]
        public JsonResult GetCates()
        {
            var cates = from c in db.Category
                        select c;

            return Json(cates, JsonRequestBehavior.AllowGet);
        }


        //GET: Cates 模态框文章信息
        [HttpGet]

        public JsonResult GetArticleInfo(int id)
        {
            var article = from a in db.Article
                          where a.id == id
                          select a;
            var json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.Data = article.ToList();
            return json;
        }

        //删除文章(批量,单个)
        [HttpPost]
        public JsonResult Delete(string Ids)
        {
            System.Diagnostics.Debug.Write(Ids);
            if (Ids == null || Ids == "")
            {
                return Json("null value");
            }
            //单个
            if (!Ids.Contains("-"))
            {
                int id = Convert.ToInt32(Ids);
                Article article = db.Article.Find(id);
                if (article == null)
                {
                    return Json("not exit ids");
                }
                db.Article.Remove(article);
                db.SaveChanges();
            }
            else
            {
                //批量
                string[] idstr = Ids.Split('-');
                foreach (string str in idstr)
                {
                    int id = Convert.ToInt32(str);
                    Article article = db.Article.Find(id);
                    db.Article.Remove(article);
                    db.SaveChanges();
                }
            }
            return Json(true);
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