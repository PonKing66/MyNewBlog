using MyNewBlog.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace MyNewBlog.App_Start
{
    //管理权限
    //类和方法都使用时，加上这个特性，此时都其作用，不加，只方法起作用
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //判断管理员是否已登录
            var admin = HttpContext.Current.Session["admin"];
            if (admin == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }
        }
    
    }
}