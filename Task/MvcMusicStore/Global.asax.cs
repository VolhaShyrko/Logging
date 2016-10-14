using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;

using MvcMusicStore.Controllers;

using NLog;

namespace MvcMusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILogger logger;

        public MvcApplication()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.Register(x => LogManager.GetLogger("ForControllers")).As<ILogger>();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            this.logger.Info("Application has started");

        }

        protected void ApplicationError()
        {
            var exeption = this.Server.GetLastError();
            this.logger.Error(exeption.ToString());
        }

    }
}
