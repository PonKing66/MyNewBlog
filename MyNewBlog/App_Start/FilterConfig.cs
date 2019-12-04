using MyNewBlog.App_Start;
using MyNewBlog.Config;
using System.Web;
using System.Web.Mvc;

namespace MyNewBlog
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomHandleErrorAttribute());
            //filters.Add(new LoginFilterAttribute());
            // filters.Add(new AuthFilter());
        }
    }
}
