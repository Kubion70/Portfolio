using CacheManager.Core;
using Portfolio.Core.Database;
using Portfolio.Core.Extensions;
using Portfolio.Data.Configurations;
using Portfolio.Data.Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Portfolio.Core.Translations
{
    public class Translator : ITranslator
    {
        private IDatabaseWrapper Database { get; }

        private ICacheManager<TranslationItem> TranslationsCache { get; }

        private TranslationsConfiguration Configuration { get; }

        public Translator(IDatabaseWrapper database, ICacheManager<TranslationItem> translationsCache, TranslationsConfiguration configuration)
        {
            Database = database;
            TranslationsCache = translationsCache;
            Configuration = configuration;
        }

        /// <exception cref="NotSupportedException"></exception>s
        public async Task<string> GetTranslationAsync(int translationId, KnownCulture culture, IDbTransaction transaction = null)
        {
            if (Configuration.Caching && TranslationsCache.Exists(translationId.ToString(), culture.GetDisplayName()))
            {
                return TranslationsCache.Get(translationId.ToString(), culture.GetDisplayName()).Value;
            }

            // If not found in cache check database
            var dbTranslationValue = await Database.ExecuteScalarAsync<string>(
                findTranslationValueSQL,
                new
                {
                    TranslationId = translationId,
                    LanguageCountryCode = culture.GetDisplayName()
                },
                transaction);

            if (dbTranslationValue != null)
            {
                if (Configuration.Caching)
                {
                    TranslationsCache.Add(new CacheItem<TranslationItem>(
                        translationId.ToString(),
                        culture.GetDisplayName(),
                        new TranslationItem
                        {
                            Value = dbTranslationValue
                        },
                        ExpirationMode.Sliding,
                        TimeSpan.FromMinutes(Configuration.CachingTimeInMinutes)));
                }

                return dbTranslationValue;
            }

            // If selected culture is defualt there is no sense to search it again
            if (culture == KnownCulture.English)
                throw new NotSupportedException("Could not found proper translation for provided culture and default culture.");

            // If there is not translation for this culture in database search for deafult in cache
            if (Configuration.Caching && TranslationsCache.Exists(translationId.ToString(), KnownCulture.English.GetDisplayName()))
            {
                return TranslationsCache.Get(translationId.ToString(), KnownCulture.English.GetDisplayName()).Value;
            }

            dbTranslationValue = await Database.ExecuteScalarAsync<string>(
                findTranslationValueSQL,
                new
                {
                    TranslationId = translationId,
                    LanguageCountryCode = KnownCulture.English.GetDisplayName()
                },
                transaction);

            if (dbTranslationValue != null)
            {
                if (Configuration.Caching)
                {
                    TranslationsCache.Add(new CacheItem<TranslationItem>(
                    translationId.ToString(),
                    KnownCulture.English.GetDisplayName(),
                    new TranslationItem
                    {
                        Value = dbTranslationValue
                    },
                    ExpirationMode.Sliding,
                    TimeSpan.FromMinutes(Configuration.CachingTimeInMinutes)));
                }

                return dbTranslationValue;
            }
            else
            {
                throw new NotSupportedException("Could not found proper translation for provided culture and default culture.");
            }
        }

        /// <summary>
        /// Returns translationId if created
        /// </summary>
        public async Task<int> CreateTranslationAsync(string translationValue, KnownCulture culture, int? translationId = null, IDbTransaction transaction = null)
        {
            if (translationId.HasValue)
            {
                if (Configuration.Caching && TranslationsCache.Exists(translationId.Value.ToString(), culture.GetDisplayName()))
                {
                    var translation = TranslationsCache.Get(translationId.ToString(), culture.GetDisplayName()).Value;

                    if (translation == translationValue)
                        return translationId.Value;

                    TranslationsCache.Update(translationId.Value.ToString(), culture.GetDisplayName(), u => new TranslationItem
                    {
                        Value = translationValue
                    });
                }

                await Database.UpdateAsync(new TranslationValue
                {
                    LanguageCountryCode = culture.GetDisplayName(),
                    TranslationId = translationId.Value,
                    Value = translationValue
                },
                transaction);

                return translationId.Value;
            }
            else
            {
                translationId = await Database.ExecuteScalarAsync<int>(insertIntoTranslationSQL, null, transaction);

                await Database.InsertAsync(new TranslationValue
                {
                    LanguageCountryCode = culture.GetDisplayName(),
                    TranslationId = translationId.Value,
                    Value = translationValue
                },
                transaction);

                return translationId.Value;
            }
        }

        private readonly string findTranslationValueSQL = @"
SELECT tv.Value
FROM Translation t
INNER JOIN TranslationValue tv
	ON tv.TranslationId = t.Id
	AND tv.LanguageCountryCode = @LanguageCountryCode
WHERE t.Id = @TranslationId;
";

        private readonly string insertIntoTranslationSQL = @"
INSERT Translation DEFAULT VALUES;
SELECT SCOPE_IDENTITY();
";
    }
}