using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using WebMVC_UnitTest.DbClasses;

namespace WebMVC_UnitTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new ProductDbInittializer());
        }
    }
}
