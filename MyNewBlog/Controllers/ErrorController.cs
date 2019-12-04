using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyNewBlog.Controllers
{
    //自定义错误页面
    public class ErrorController : Controller
    {
        //[Route("401")]
        public ActionResult HttpError401()
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return View();
        }

        //[Route("404")]
        public ActionResult HttpError404()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        //[Route("403")]
        public ActionResult HttpError403()
        {
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return View();
        }

        //[Route("500")]
        public ActionResult HttpError500()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }
    }
}