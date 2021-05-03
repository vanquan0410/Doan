using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace OnlineShop
{
    /// <summary>
    /// Bootstrapper
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Initialise
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();   

            //dependency injectsion
            //container.RegisterType(typeof(ISQLServerContext<>), typeof(SQLServerContext<>));
            RegisterTypes(container);

            return container;
        }

        /// <summary>
        /// RegisterTypes
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}