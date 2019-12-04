using MyNewBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNewBlog.Config
{
    public class AuthorizeCheckAttribute :AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                try
                {
                    filterContext.Controller.TempData.Add("Alert", new Alert { Type = AlertType.Error, Message = "请登录后访问" });
                }
                catch { }
                filterContext.Result = new ViewResult
                {
                    TempData = filterContext.Controller.TempData,
                    ViewName = "~/Views/Error/HttpError401.cshtml"
                };
                //new RedirectResult("~/error/httperror401");
            }
        }
    }
}