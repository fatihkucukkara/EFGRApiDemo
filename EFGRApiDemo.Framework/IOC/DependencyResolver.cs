using Autofac;
using Autofac.Integration.WebApi;
using EFGRApiDemo.Dal.Base.Interfaces;
using EFGRApiDemo.Dal.Repositories;
using EFGRApiDemo.Data.Context;
using EFGRApiDemo.Implementation;
using System.Reflection;

namespace EFGRApiDemo.Framework.IOC
{
    public static class DependencyResolver
    {

        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetCallingAssembly()).InstancePerLifetimeScope();

            builder.Register(c => new SchoolContext()).As<SchoolContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<SchoolService>().As<ISchoolService>().InstancePerLifetimeScope();

            var container = builder.Build();

            Container = container;
            return container;
        }

        public static IContainer Container { get; private set; }
    }
}
