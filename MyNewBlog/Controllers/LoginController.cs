
using MyNewBlog.Models;
using System.Data;
using System.Linq;
using System.Web.Mvc;


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
        [ValidateInput(false)]
        public ActionResult Index(Admin admin)
        {
            if (ModelState.IsValid)
            {
                //查询是否存在该账户
                var result = from a in db.Admin
                             where a.adminName == admin.adminName
                             select a;
                if (result.Count()>0&&result.First().adminPassword != admin.adminPassword)
                {
                    ModelState.AddModelError("AdminError", "用户密码或账户错误");
                    return View("Login");
                }

                //若是管理员,则重定向/admin/Index,否则回主页面
                Session["admin"] = admin;
                HttpContext.Session.Timeout = 15;
                return Redirect("~/Manage/articles");
                
            }
            return View("Login");
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }



        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

 
   


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
