using MyNewBlog.Controllers;
using MyNewBlog.ViewConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyNewBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterView();
           // System.Web.HttpContext.Current.Request.Cookies.Clear();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            HttpException httpException = exception as HttpException;

            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "Error");

            switch (httpException.GetHttpCode())
            {
                case 404:
                    routeData.Values.Add("action", "HttpError404");
                    break;
            }

            Response.Clear();
            Server.ClearError();
            Response.TrySkipIisCustomErrors = true;
            IController errorController = new ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));

            //Response.RedirectToRoute(new { controller = "Error", action = "HttpError404" });
        }

        protected void RegisterView()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ViewEngine());
        }

    }
}
