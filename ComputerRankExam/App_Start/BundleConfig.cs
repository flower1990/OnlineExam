using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ComputerRankExam
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.7.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/online").Include(
                        "~/Scripts/jquery.ResetSize.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-ie").Include(
                      "~/Content/bootstrap/js/bootstrap-ie.js"));


            bundles.Add(new StyleBundle("~/Css/layout").Include(
                        "~/Content/Css/style.css",
                        "~/Content/Css/lrtk.css",
                        "~/Content/Css/responsiveslides.css"));

            bundles.Add(new StyleBundle("~/Css/layout_ie6").Include(
                        "~/Content/Css/style_ie6.css",
                        "~/Content/Css/lrtk_ie6.css",
                        "~/Content/Css/responsiveslides_ie6.css"));

            bundles.Add(new StyleBundle("~/Css/bootstrap").Include(
                        "~/Content/bootstrap/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Css/bootstrap-ie6").Include(
                        "~/Content/bootstrap/css/bootstrap-ie6.css"));

            bundles.Add(new StyleBundle("~/Css/ie").Include(
                        "~/Content/bootstrap/css/ie.css"));

            bundles.Add(new StyleBundle("~/Css/member").Include(
                        "~/Content/bootstrap/css/member.css"));
        }
    }
}