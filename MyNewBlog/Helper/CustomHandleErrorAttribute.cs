using MyNewBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNewBlog.Config
{
    public class CustomHandleErrorAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception exception = filterContext.Exception;
            try
            {
                //TODO:写错误日志
                filterContext.Controller.TempData.Add("Alert", new Alert { Type = AlertType.Error, Message = exception.ToString() });
            }
            catch { }
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            //filterContext.Result = new RedirectResult("~/error/httperror500");
            filterContext.Result = new ViewResult
            {
                TempData = filterContext.Controller.TempData,
                ViewName = "~/Views/Error/HttpError500.cshtml"
            };
            //var Result = this.View("Error", new HandleErrorInfo(exception,
            //filterContext.RouteData.Values["controller"].ToString(),
            //filterContext.RouteData.Values["action"].ToString()));

            //filterContext.Result = Result;
        }
    }
}