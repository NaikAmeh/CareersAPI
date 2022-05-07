using Model.Core.Factories;
using Model.Core.Interfaces;
using Model.Core.Repositories;
using Models.Core.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Lifestyles;
using System.Reflection;
using System.Web.Mvc;

namespace CareerService.App_Start
{
    public static class SimpleInjectorInitialize
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register(typeof(IRepository<>), typeof(Repository<>));
            container.Register<JobFactory>();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            NHibernateHelper.RegisterResource(container);
        }
    }
}