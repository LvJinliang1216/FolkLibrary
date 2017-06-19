using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FolkLibrary.Configuration.ControllerConfiguration;
using FolkLibrary.Configuration.Initialization;
using FolkLibrary.Configuration.UnityConfiguration;

namespace FolkLibrary.Manager
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Initialization.AutoMapperInitialization();
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(new UnityConfig()._container));
        }
    }
}