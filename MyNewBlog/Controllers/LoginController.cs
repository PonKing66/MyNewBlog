using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyNewBlog.Models;

namespace MyNewBlog.Controllers
{
    public class LoginController : Controller
    {
        private NewsInformationEntities db = new NewsInformationEntities();

        // GET: Login
        public ActionResult Index()
        {

            return View("Login");
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            //查询是否存在该账户
            var result = from a in db.Admin
                         where a.adminName == admin.adminName
                         select a;
            if (result.Count() == 0)
            {
                return View("Error");
            }
            Admin admin1 = db.Admin.Find(result.First().id);
            if (admin1.adminPassword == admin.adminPassword)
            {
                //若是管理员,则重定向/admin/Index,否则回主页面
                Session["admin"] = admin;
                return Redirect("~/admin/Index");
            }
            else
            {
                return View("Login");
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }



        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
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
