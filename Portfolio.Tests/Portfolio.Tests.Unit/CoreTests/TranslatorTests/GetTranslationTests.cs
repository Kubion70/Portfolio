using CacheManager.Core;
using Moq;
using NUnit.Framework;
using Portfolio.Core.Database;
using Portfolio.Core.Extensions;
using Portfolio.Core.Translations;
using Portfolio.Data.Configurations;
using System;
using System.Threading.Tasks;

namespace Portfolio.Tests.Unit.CoreTests.TranslatorTests
{
    public class GetTranslationTests
    {
        [Test]
        public async Task TranslationInCacheNotInDb_TranslationRetrieved()
        {
            int translationId = 1;
            var culture = KnownCulture.Polish;
            var translationValue = "test";

            // Preparing cache
            var cache = CacheFactory.Build<TranslationItem>(s => s.WithDictionaryHandle());
            cache.Add(
                translationId.ToString(),
                new TranslationItem
                {
                    Value = translationValue
                },
                culture.GetDisplayName());

            var translatorConfiguration = new TranslationsConfiguration
            {
                Caching = true,
                CachingTimeInMinutes = 1
            };

            var translator = new Translator(null, cache, translatorConfiguration);

            var returnedTranslation = await translator.GetTranslationAsync(translationId, culture);

            Assert.AreEqual(translationValue, returnedTranslation);
        }

        [Test]
        public void TranslationNotInCacheNotInDb_TranslatorThrows()
        {
            int translationId = 1;
            var culture = KnownCulture.Polish;

            var cache = CacheFactory.Build<TranslationItem>(s => s.WithDictionaryHandle());

            var translatorConfiguration = new TranslationsConfiguration
            {
                Caching = true,
                CachingTimeInMinutes = 1
            };

            var dbMock = new Mock<IDatabaseWrapper>();
            dbMock.Setup(db => db.ExecuteScalarAsync<string>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    null,
                    null,
                    null))
                .ReturnsAsync(null as string);

            var returnedTranslation = new Translator(dbMock.Object, cache, translatorConfiguration);

            Assert.ThrowsAsync<NotSupportedException>(
                async () => await returnedTranslation.GetTranslationAsync(translationId, culture, null)
                );
        }

        [Test]
        public async Task TranslationNotInCacheNotInDb_DefaultTranslationInCahce_DefaultTranslationReturned()
        {
            int translationId = 1;
            var culture = KnownCulture.Polish;

            var translationValue = "test";

            // Preparing cache
            var cache = CacheFactory.Build<TranslationItem>(s => s.WithDictionaryHandle());
            cache.Add(
                translationId.ToString(),
                new TranslationItem
                {
                    Value = translationValue
                },
                KnownCulture.English.GetDisplayName()); // Default culture

            var translatorConfiguration = new TranslationsConfiguration
            {
                Caching = true,
                CachingTimeInMinutes = 1
            };

            var dbMock = new Mock<IDatabaseWrapper>();
            dbMock.Setup(db => db.ExecuteScalarAsync<string>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    null,
                    null,
                    null))
                .ReturnsAsync(null as string);

            var translator = new Translator(dbMock.Object, cache, translatorConfiguration);

            var returnedTranslation = await translator.GetTranslationAsync(translationId, culture);

            Assert.AreEqual(translationValue, returnedTranslation);
        }

        [Test]
        public async Task TranslationNotInCacheNotInDb_DefaultTranslationInDb_DefaultTranslationReturned()
        {
            int translationId = 1;
            var culture = KnownCulture.Polish;

            var translationValue = "test";

            // Preparing cache
            var cache = CacheFactory.Build<TranslationItem>(s => s.WithDictionaryHandle());

            var translatorConfiguration = new TranslationsConfiguration
            {
                Caching = true,
                CachingTimeInMinutes = 1
            };

            var dbMock = new Mock<IDatabaseWrapper>();
            dbMock.SetupSequence(db => db.ExecuteScalarAsync<string>(It.IsAny<string>(),
                    It.IsAny<object>(),
                    null,
                    null,
                    null))
                .ReturnsAsync(null as string)
                .ReturnsAsync(translationValue);

            var translator = new Translator(dbMock.Object, cache, translatorConfiguration);

            var returnedTranslation = await translator.GetTranslationAsync(translationId, culture);

            Assert.AreEqual(translationValue, returnedTranslation);
        }
    }
}