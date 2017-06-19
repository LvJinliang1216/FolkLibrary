using System.Web.Optimization;

namespace FolkLibrary.Manager
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include("~/Scripts/jquery-3.2.0.min.js"));

            #region easyui 1.4.5
            bundles.Add(new StyleBundle("~/Content/easyui")
                .Include("~/Content/themes/default/easyui.css")
                .Include("~/Content/themes/icon.css"));

            bundles.Add(new ScriptBundle("~/Scripts/easyui")
                .Include("~/Scripts/jquery.easyui-1.4.5.min.js")
                .Include("~/Scripts/locale/easyui-lang-zh_CN.js"));
            #endregion

            #region 登录页面
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/css/wu.css")
                .Include("~/Content/css/icon.css"));

            bundles.Add(new ScriptBundle("~/Scripts/login")
                .Include("~/Scripts/Login/placeholder.js"));

            bundles.Add(new ScriptBundle("~/Style/login")
                .Include("~/Content/Login/style.css"));
            #endregion

            #region Ueditor 富文本编辑器

            bundles.Add(new ScriptBundle("~/Scripts/Ueditor")
                .Include("~/Scripts/Ueditor/ueditor.config.js")
                .Include("~/Scripts/Ueditor/ueditor.all.min.js"));

            #endregion

            #region 自定义函数js文件

            bundles.Add(new ScriptBundle("~/Scripts/common")
                .Include("~/Scripts/common.js"));
            #endregion
        }
    }
}