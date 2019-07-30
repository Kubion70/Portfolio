using Portfolio.Core.Database;
using Portfolio.Core.Translations;
using Portfolio.IOC;
using Portfolio.Tests.Common.ObjectMothers;

namespace Portfolio.Tests.Integration
{
    public class ObjectMothers
    {
        public MainPageConfigurationObjectMother MainPageConfiguration { get; }

        public KnownTechnologyObjectMother KnownTechnologyObjectMother { get; }

        public ObjectMothers()
        {
            var translator = Handler.Resolve<ITranslator>();
            var database = Handler.Resolve<IDatabaseWrapper>();

            MainPageConfiguration = new MainPageConfigurationObjectMother(translator, database);
            KnownTechnologyObjectMother = new KnownTechnologyObjectMother(database);
        }
    }
}
