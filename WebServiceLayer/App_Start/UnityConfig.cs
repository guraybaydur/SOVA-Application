using Microsoft.Practices.Unity;
using System.Web.Http;
using DataAccessLayer;
using MySqlDatabase;
using Unity.WebApi;

namespace WebServiceLayer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRepository, MySqlRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}