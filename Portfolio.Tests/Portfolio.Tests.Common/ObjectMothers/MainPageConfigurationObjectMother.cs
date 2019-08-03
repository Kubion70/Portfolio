using Portfolio.Core.Database;
using Portfolio.Core.Translations;
using Portfolio.Data.Entities;
using System.Threading.Tasks;

namespace Portfolio.Tests.Common.ObjectMothers
{
    public class MainPageConfigurationObjectMother
    {
        private ITranslator Translator { get; }

        private IDatabaseWrapper Database { get; }

        public MainPageConfigurationObjectMother(ITranslator translator, IDatabaseWrapper database)
        {
            Translator = translator;
            Database = database;
        }

        public async Task<MainPageConfiguration> CreateWithDefaultTranslationsAsync()
        {
            var sql = @"
INSERT INTO MainPageConfiguration (
    Title, 
    SubTitle,
    TopImageUrl, 
    TopDescriptionTranslationId, 
    AboutMeDescriptionTranslationId,
    Phone,
    Email,
    Facebook,
    LinkedIn,
    GitHub,
    GitLab
) VALUES (
    @Title,
    @SubTitle,
    @TopImageUrl,
    @TopDescriptionTranslationId,
    @AboutMeDescriptionTranslationId,
    @Phone,
    @Email,
    @Facebook,
    @LinkedIn,
    @GitHub,
    @GitLab
);
SELECT CAST(SCOPE_IDENTITY() as int)
";

            var mainPageConfiguration = new MainPageConfiguration
            {
                Title = "Title test",
                SubTitle = "Subtitle test",
                TopImageUrl = "http://example.com",
                TopDescriptionTranslationId = await Translator.CreateTranslationAsync("Top description in English", KnownCulture.English),
                AboutMeDescriptionTranslationId = await Translator.CreateTranslationAsync("About me description in English", KnownCulture.English),
                Phone = "+12 345 678 910",
                Email = "sample@example.com",
                Facebook = "http://Facebook.com",
                LinkedIn = "http://LinkedIn.com",
                GitHub = "http://GitHub.com",
                GitLab = "http://GitLab.com"
            };

            mainPageConfiguration.Id = await Database.ExecuteScalarAsync<int>(sql, mainPageConfiguration);
            return mainPageConfiguration;
        }
    }
}
