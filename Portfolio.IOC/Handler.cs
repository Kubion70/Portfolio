using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.LogicAbstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.IOC
{
    public static class Handler
    {
        private static IWindsorContainer Container { get; set; }

        private const string LOGIC_PROJECT_NAME = "Portfolio.BusinessLogic";

        public static IServiceProvider Configure(IServiceCollection services = null)
        {
            Container = new WindsorContainer();

            Container.Register(
                Classes.FromAssemblyNamed(LOGIC_PROJECT_NAME)
                .BasedOn(typeof(ILogic<>))
                .WithService.FirstInterface()
                .LifestyleTransient());

            if (services != null)
                return WindsorRegistrationHelper.CreateServiceProvider(Container, services);
            else
                return null;
        }

        public static ILogic<Result> ResolveLogic<Result>()
            where Result : ILogicResult
            => Container.Resolve<ILogic<Result>>();
    }
}
