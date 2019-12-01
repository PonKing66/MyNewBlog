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
            System.Diagnostics.Debug.WriteLine(u.userName);
            if (u.userAccount == user.userAccount)
            {
                //若是管理员,则重定向/admin/Index,否则回主页面
                CreateLogCookie(u);
                if (user.userAccount == "admin")
                {
                    
                    return Redirect("~/admin/Index");
                }
                return Redirect("~/Home/Index");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            System.Diagnostics.Debug.WriteLine("Logout ok");
            //HttpCookie cookieName = System.Web.HttpContext.Current.Request.Cookies.Get("account");
            HttpContext.Response.Cookies["Account"].Expires = DateTime.Now.AddDays(-11);
            return Redirect("~/Home/Index");
        }

        #region 将用户名存到cookie中
        /// <summary>
        /// 保存Cookie
        /// </summary>
        /// <returns></returns>
        public void CreateLogCookie(User user)   //此Action自动往cookie里写入登录信息
        {
 
            System.Diagnostics.Debug.WriteLine(user.userName);
            HttpCookie UserAccount = new HttpCookie("Account");
            

            UserAccount.Values["userAccount"] = user.userAccount;
           // UserAccount.Values["userPwd"] = user.userPassword;
            UserAccount.Values["userName"] = user.userName;
            UserAccount.Values["IsAdmin"] = user.isAdmin==1?"True":"False";
            System.Web.HttpContext.Current.Response.SetCookie(UserAccount);
            //cookie保存时间
            UserAccount.Expires = DateTime.Now.AddHours(0.5);
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
