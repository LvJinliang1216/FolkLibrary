using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FolkLibrary.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include("~/Scripts/jquery-3.2.0.min.js").Include("~/Scripts/common.js"));
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap")
                .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/MvcPager")
                .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                .Include("~/Scripts/MvcPager.js"));

            bundles.Add(new ScriptBundle("~/Scripts/datetimepicker")
                .Include("~/Scripts/moment-with-locales.min.js")
                .Include("~/Scripts/bootstrap-datetimepicker.min.js"));

            //ECharts的JS文件
            bundles.Add(new ScriptBundle("~/Scripts/bundles/echarts")
                .Include("~/Scripts/echarts.min.js")
                .Include("~/Scripts/china_map.js")
                .Include("~/Scripts/china.js")
                );

            bundles.Add(new StyleBundle("~/Contents/bootstrap")
                .Include("~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-datetimepicker")
                .Include("~/Content/bootstrap-datetimepicker.min.css"));


        }
    }
}