using NUnit.Framework;
using Portfolio.BusinessLogic.MainPage.GetMainPageData;
using Portfolio.Core.Translations;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Tests.Integration.MainPage
{
    public class GetMainPageDataQueryTests : IntegrationTests
    {
        [Test]
        public async Task DataExists_DataReturned()
        {
            var userContext = GetUserContext(KnownCulture.Polish);

            var mainPageConfiguration = await ObjectMothers.MainPageConfiguration.CreateWithDefaultTranslationsAsync();

            var technologies = new List<KnownTechnology>();

            for(int i = 0; i < 10; i++)
            {
                technologies.Add(await ObjectMothers.KnownTechnologyObjectMother.CreateAsync(mainPageConfiguration.Id));
            }

            var offerItems = new List<OfferItem>();

            for(int i = 0; i < 10; i++)
            {
                offerItems.Add(await ObjectMothers.OfferItemObjectMother.Create(mainPageConfiguration.Id));
            }

            var queryExecution = await DispatchQueryAsync(new GetMainPageDataRequest());

            Assert.That(queryExecution.ValidationErrors, Is.Empty);
            Assert.That(queryExecution.QueryResult, Is.Not.Null);
            Assert.That(queryExecution.QueryResult.Title, Is.EqualTo(mainPageConfiguration.Title));
            Assert.That(queryExecution.QueryResult.SubTitle, Is.EqualTo(mainPageConfiguration.SubTitle));
            Assert.That(queryExecution.QueryResult.TopImageUrl, Is.EqualTo(mainPageConfiguration.TopImageUrl));
            Assert.That(queryExecution.QueryResult.Phone, Is.EqualTo(mainPageConfiguration.Phone));
            Assert.That(queryExecution.QueryResult.Email, Is.EqualTo(mainPageConfiguration.Email));
            Assert.That(queryExecution.QueryResult.Facebook, Is.EqualTo(mainPageConfiguration.Facebook));
            Assert.That(queryExecution.QueryResult.LinkedIn, Is.EqualTo(mainPageConfiguration.LinkedIn));
            Assert.That(queryExecution.QueryResult.GitHub, Is.EqualTo(mainPageConfiguration.GitHub));
            Assert.That(queryExecution.QueryResult.GitLab, Is.EqualTo(mainPageConfiguration.GitLab));

            var topDescriptionTranslated = await Translator.GetTranslationAsync(mainPageConfiguration.TopDescriptionTranslationId, userContext.Culture);
            var aboutMeDescriptionTranslated = await Translator.GetTranslationAsync(mainPageConfiguration.AboutMeDescriptionTranslationId, userContext.Culture);

            Assert.That(queryExecution.QueryResult.TopDescription, Is.EqualTo(topDescriptionTranslated));
            Assert.That(queryExecution.QueryResult.AboutMeDescription, Is.EqualTo(aboutMeDescriptionTranslated));

            Assert.That(queryExecution.QueryResult.KnownTechnologies.Count(), Is.EqualTo(technologies.Count));
            Assert.That(queryExecution.QueryResult
                .KnownTechnologies.All(t => technologies.Any(dbTech => dbTech.Name == t.Name && dbTech.KnownLevel == t.KnownLevel)),
                Is.True);

            Assert.That(queryExecution.QueryResult.OfferItems.Count(), Is.EqualTo(offerItems.Count));
            Assert.That(queryExecution.QueryResult
                .OfferItems.All(o => offerItems.Any(dbOffer => {
                    return dbOffer.Icon == o.Icon
                        && Translator.GetTranslationAsync(dbOffer.TitleTranslationId, userContext.Culture).Result == o.Title
                        && Translator.GetTranslationAsync(dbOffer.DescriptionTranslationId, userContext.Culture).Result == o.Description;
                    })));
        }

        [Test]
        public void DataNotExists_QueryThrows()
        {
            GetUserContext(KnownCulture.Polish);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await DispatchQueryAsync(new GetMainPageDataRequest()));
        }
    }
}
