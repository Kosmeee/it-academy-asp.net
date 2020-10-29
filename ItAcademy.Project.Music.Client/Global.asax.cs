using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ItAcademy.Project.Music.Client.App_Start;

namespace ItAcademy.Project.Music.Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.ConfigureContainer();
        }
    }
}
