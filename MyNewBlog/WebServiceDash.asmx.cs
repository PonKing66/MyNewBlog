using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyNewBlog.Controllers
{
    /// <summary>
    /// WebServiceDash 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class WebServiceDash : System.Web.Services.WebService
    {

        [WebMethod]
        public  string HelloWorld()
        {
            return "true";
        }


        [WebMethod]
        public string Test(string Ids)
        {
            return Ids;
        }

        [WebMethod]
        public static string SayHello(string Name, string Content)
        {
            return Name + "&nbsp" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "<br /> " + "Content:" + Content;
        }
    }
}
