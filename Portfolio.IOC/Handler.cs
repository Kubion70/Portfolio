﻿using CacheManager.Core;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.Contexts;
using Portfolio.Core.Database;
using Portfolio.Core.LogicAbstractions;
using Portfolio.Core.QueryAbstractions;
using Portfolio.Core.Translations;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Portfolio.IOC
{
    public static class Handler
    {
        private static IWindsorContainer Container { get; set; }

        private const string LOGIC_PROJECT_NAME = "Portfolio.BusinessLogic";

        public static IServiceProvider Configure(IServiceCollection services = null)
        {
            if(Container == null)
                Container = new WindsorContainer();

            IServiceProvider serviceProvider = services != null ? WindsorRegistrationHelper.CreateServiceProvider(Container, services) : null;

            var configuration = Container.Resolve<IConfiguration>();

            Container.Register(
                Classes.FromAssemblyNamed(LOGIC_PROJECT_NAME)
                .BasedOn(typeof(ILogic<>))
                .OrBasedOn(typeof(IQuery<>))
                .OrBasedOn(typeof(IValidator<>))
                .WithService.FirstInterface()
                .LifestyleTransient());

            Container.Register(
                Component.For<ITranslator>()
                .ImplementedBy<Translator>()
                .LifestyleTransient());

            var cache = CacheFactory.Build<TranslationItem>("Translations", settings =>
            {
                settings.WithDictionaryHandle();
            });

            Container.Register(
                Component.For<ICacheManager<TranslationItem>>()
                .Instance(cache)
                .LifestyleSingleton());

            Container.Register(
                Component.For<IDbConnection>()
                .Instance(new SqlConnection(configuration["ConnectionString"]))
                .LifestyleTransient());

            Container.Register(
                Component.For<IDatabaseWrapper>()
                .ImplementedBy<DatabaseWrapper>()
                .LifestyleTransient());

            Container.Register(
                Component.For<UserContextFactory>()
                .ImplementedBy<UserContextFactory>()
                .LifestyleScoped());

            Container.Register(
                Component.For<IUserContext>()
                .UsingFactory<UserContextFactory, IUserContext>(factory => factory.CreateUserContext())
                .LifestyleScoped());

            return serviceProvider;
        }

        public static void Release(object objectToRelease) => Container.Release(objectToRelease);

        public static void ResetContainer()
        {
            if(Container != null)
                Container.Dispose();

            Container = new WindsorContainer();
        }

        public static T Resolve<T>() => Container.Resolve<T>();

        public static IDisposable BeginScope()
        {
            return Container.BeginScope();
        }

        public static void Register(params IRegistration[] registrations)
        {
            if (Container == null)
                Container = new WindsorContainer();

            Container.Register(registrations);
        }

        public static ILogic<Result> ResolveLogic<Result>()
            where Result : ILogicResult
            => Container.Resolve<ILogic<Result>>();

        public static IQuery<Result> ResolveQuery<Result>()
            => Container.Resolve<IQuery<Result>>();
    }
}