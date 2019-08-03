using Portfolio.Core.Database;
using Portfolio.Core.Translations;
using Portfolio.Data.Entities;
using System.Threading.Tasks;

namespace Portfolio.Tests.Common.ObjectMothers
{
    public class OfferItemObjectMother
    {
        private ITranslator Translator { get; }

        private IDatabaseWrapper Database { get; }

        private static int counter = 0;

        public OfferItemObjectMother(ITranslator translator, IDatabaseWrapper database)
        {
            Translator = translator;
            Database = database;
        }

        public async Task<OfferItem> Create(int mainPageConfiguration)
        {
            counter++;

            var sql = @"
INSERT INTO OfferItem (
    Icon,
    TitleTranslationId,
    DescriptionTranslationId,
    MainPageConfigurationId
) VALUES (
    @Icon,
    @TitleTranslationId,
    @DescriptionTranslationId,
    @MainPageConfigurationId
);
SELECT CAST(SCOPE_IDENTITY() as int);
";

            var offerItem = new OfferItem
            {
                Icon = "icon_name_" + counter,
                TitleTranslationId = await Translator.CreateTranslationAsync("Title_" + counter, KnownCulture.English),
                DescriptionTranslationId = await Translator.CreateTranslationAsync("Description " + counter, KnownCulture.English),
                MainPageConfigurationId = mainPageConfiguration
            };

            offerItem.Id = await Database.ExecuteScalarAsync<int>(sql, offerItem);

            return offerItem;
        }
    }
}
