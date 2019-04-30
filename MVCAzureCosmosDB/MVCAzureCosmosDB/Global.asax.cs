using MVCAzureCosmosDB.DB;
using MVCAzureCosmosDB.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCAzureCosmosDB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DocumentDBRepository<Office>.Initialize();
            DocumentDBRepository<OfficeDetails>.Initialize();
        }
    }
}
