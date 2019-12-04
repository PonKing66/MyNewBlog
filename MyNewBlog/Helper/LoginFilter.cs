using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNewBlog.App_Start
{
    //管理权限
    //类和方法都使用时，加上这个特性，此时都其作用，不加，只方法起作用
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// OnActionExecuting是Action执行前的操作
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //判断Cookie用户名密码是否存在
            //HttpContext.Current.Request.ContentEncoding.
            HttpCookie cookieName = HttpContext.Current.Request.Cookies.Get("Account");
            if (cookieName == null || ( cookieName.Values["IsAdmin"] != "True"|| cookieName.Values["userAccount"]!="admin"))
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }

        }
    
    }
}