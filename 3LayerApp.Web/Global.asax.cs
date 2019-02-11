using _3LayerApp.BLL.Ioc;
using _3LayerApp.Web.Utils;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using System.Web.Routing;

namespace _3LayerApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Register Dependencies here
            NinjectModule presentationLayerModule = new ServicesModule();
            NinjectModule businessLayerModule = new ServiceModule("BankDBEntities");

            var kernel = new StandardKernel(presentationLayerModule, businessLayerModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
