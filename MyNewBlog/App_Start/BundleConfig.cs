using System.Web;
using System.Web.Optimization;

namespace MyNewBlog
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/html5.js",
                        "~/Scripts/holder.js",
                        "~/Scripts/script.js",
                        "~/Scripts/css3-mediaqueries.js",
                        "~/Scripts/jquery1111.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bootstrap-4.3.1-dist/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-4.3.1-dist/css/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/html5.css",
                      "~/Content/menu.css",
                      "~/Content/style.css",
                      "~/Content/zerogrid.css",
                      "~/Content/dashboard.css"));

            bundles.Add(new StyleBundle("~/Content/Dash/css").Include(
                      "~/Content/bootstrap-4.3.1-dist/css/bootstrap.css",
                      "~/Content/dashboard.css"));

            bundles.Add(new StyleBundle("~/owl-carousel/css").Include(
                      "~/owl-carousel/owl-carousel.css"));

            //自定义

        }
    }
}
