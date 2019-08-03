using Castle.MicroKernel.Registration;
using DbUp;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Portfolio.Core.Contexts;
using Portfolio.Core.Database;
using Portfolio.Core.LogicAbstractions;
using Portfolio.Core.QueryAbstractions;
using Portfolio.Core.Translations;
using Portfolio.Data.Configurations;
using Portfolio.Database;
using Portfolio.IOC;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Portfolio.Tests.Integration
{
    [TestFixture]
    public abstract class IntegrationTests
    {
        protected ObjectMothers ObjectMothers { get; set; }

        protected IDatabaseWrapper Database { get; set; }

        protected ITranslator Translator { get; set; }

        private TransactionScope TransactonScope { get; set; }

        private IDisposable HandlerScope { get; set; }

        private IConfiguration Configuration { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Configuration = GetIConfigurationRoot();

            new DbUpgrader(Configuration["ConnectionString"]).Upgrade();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DropDatabase.For.SqlDatabase(Configuration["ConnectionString"]);
        }

        [SetUp]
        public void Init()
        {
            Handler.ResetContainer();

            TransactonScope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            Handler.Register(
                Component.For<IConfiguration>()
                .Instance(Configuration)
                .LifestyleSingleton());

            var translationsConfiguration = new TranslationsConfiguration();
            Configuration.Bind("Translations", translationsConfiguration);

            Handler.Register(
                Component.For<TranslationsConfiguration>()
                .Instance(translationsConfiguration)
                .LifestyleSingleton());

            Handler.Configure();

            HandlerScope = Handler.BeginScope();

            ObjectMothers = new ObjectMothers();

            Database = Handler.Resolve<IDatabaseWrapper>();

            Translator = Handler.Resolve<ITranslator>();
        }

        [TearDown]
        public void Dispose()
        {
            if (HandlerScope != null)
                HandlerScope.Dispose();

            if (TransactonScope != null)
                TransactonScope.Dispose();
        }

        protected IUserContext GetUserContext(KnownCulture culture)
        {
            var userContext = new UserContext(culture);

            Handler.Register(
                Component.For<IUserContext>()
                .Instance(userContext)
                .IsDefault()
                .Named("Context Replaced")
                .LifestyleScoped());

            return Handler.Resolve<IUserContext>();
        }

        private static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        protected async Task<LogicExecution<Result>> DispatchLogicAsync<Result>(ILogicRequest<Result> request)
            where Result : ILogicResult
        {
            var logic = Handler.ResolveLogic<Result>();

            return await logic.ExecuteAsync(request);
        }

        protected async Task<QueryExecution<Result>> DispatchQueryAsync<Result>(IQueryRequest<Result> request)
        {
            var query = Handler.ResolveQuery<Result>();

            return await query.ExecuteAsync(request);
        }
    }
}
