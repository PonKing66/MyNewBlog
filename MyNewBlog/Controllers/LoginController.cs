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
        public ActionResult Index(User user)
        {
            
            //查询是否存在该账户
            var result = from ur in db.User
                         where ur.userAccount == user.userAccount
                         select ur;
            if (result.Count() == 0)
            {
                return View("Error");
            }
            User u = db.User.Find(result.First().id);

            if (u.userAccount == user.userAccount)
            {
                CreateCookie(user.userPassword,user.userAccount);
                return Redirect("~/admin/Index");
            }
            else
            {
                return View("Login");
            }
        }



        #region 将用户名存到cookie中
        /// <summary>
        /// 保存Cookie
        /// </summary>
        /// <returns></returns>
        public void CreateCookie(string userPwd,string userAccount)   //此Action自动往cookie里写入登录信息
        {
            System.Diagnostics.Debug.WriteLine(userPwd);
            System.Diagnostics.Debug.WriteLine(userAccount);
            HttpCookie UserAccount = new HttpCookie("account");
            UserAccount.Values["userAccount"] = userAccount;
            UserAccount.Values["userPwd"] = userPwd;
            System.Web.HttpContext.Current.Response.SetCookie(UserAccount);
            //cookie保存时间
            UserAccount.Expires = DateTime.Now.AddHours(10);
        }
        #endregion


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
