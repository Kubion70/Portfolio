using Portfolio.Core.QueryAbstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Portfolio.BusinessLogic.MainPage.GetMainPageData.GetMainPageDataResult;

namespace Portfolio.BusinessLogic.MainPage.GetMainPageData
{
    public class GetMainPageDataQuery : Query<GetMainPageDataRequest, GetMainPageDataResult>
    {
        protected override async Task<GetMainPageDataResult> Execute(GetMainPageDataRequest request)
        {
            var queryResult = await Database.QuerySingleAsync<QueryResultDataSet>(GET_MAIN_PAGE_DATA_SQL);

            var knownTechnologies = await Database.QueryAsync<KnownTechnologyResult>(
                GET_KNOWN_TECHNOLOGIES_SQL, 
                new { MainPageConfigurationId = queryResult.MainPageId });

            var offerItems = await Database.QueryAsync<OfferItemQurryResult>(
                GET_OFFER_ITEMS_SQL,
                new { MainPageConfigurationId = queryResult.MainPageId });

            var offerItemsResult = new List<OfferItemResult>();
            foreach(var item in offerItems)
            {
                offerItemsResult.Add(new OfferItemResult
                {
                    Icon = item.Icon,
                    Title = await Translator.GetTranslationAsync(item.TitleTranslationId, UserContext.Culture),
                    Description = await Translator.GetTranslationAsync(item.DescriptionTranslationId, UserContext.Culture)
                });
            }

            return new GetMainPageDataResult
            {
                Title = queryResult.Title,
                SubTitle = queryResult.SubTitle,
                TopImageUrl = queryResult.TopImageUrl,
                TopDescription = await Translator.GetTranslationAsync(queryResult.TopDescriptionTranslationId, UserContext.Culture),
                AboutMeDescription = await Translator.GetTranslationAsync(queryResult.AboutMeDescriptionTranslationId, UserContext.Culture),
                Phone = queryResult.Phone,
                Email = queryResult.Email,
                Facebook = queryResult.Facebook,
                LinkedIn = queryResult.LinkedIn,
                GitHub = queryResult.GitHub,
                GitLab = queryResult.GitLab,
                KnownTechnologies = knownTechnologies,
                OfferItems = offerItemsResult
            };
        }

        private const string GET_MAIN_PAGE_DATA_SQL = @"
SELECT TOP 1
    mpc.Id AS MainPageId,
	mpc.Title AS Title,
	mpc.SubTitle AS SubTitle,
	mpc.TopImageUrl AS TopImageUrl,
    mpc.Email,
    mpc.Phone,
    mpc.Facebook,
    mpc.LinkedIn,
    mpc.GitHub,
    mpc.GitLab,
	mpc.AboutMeDescriptionTranslationId AS AboutMeDescriptionTranslationId,
	mpc.TopDescriptionTranslationId AS TopDescriptionTranslationId
FROM MainPageConfiguration mpc
ORDER BY mpc.Id DESC
";

        private const string GET_KNOWN_TECHNOLOGIES_SQL = @"
SELECT
	kt.KnownLevel AS KnownLevel,
	kt.Name AS Name
FROM KnownTechnology kt
WHERE kt.MainPageConfigurationId = @MainPageConfigurationId;
";

        private const string GET_OFFER_ITEMS_SQL = @"
SELECT
	o.Icon,
	o.TitleTranslationId,
	o.DescriptionTranslationId
FROM OfferItem o
WHERE o.MainPageConfigurationId = @MainPageConfigurationId
";

        internal class QueryResultDataSet
        {
            public int MainPageId { get; set; }

            public string Title { get; set; }

            public string SubTitle { get; set; }

            public string TopImageUrl { get; set; }

            public int AboutMeDescriptionTranslationId { get; set; }

            public int TopDescriptionTranslationId { get; set; }

            public string Phone { get; set; }

            public string Email { get; set; }

            public string Facebook { get; set; }

            public string LinkedIn { get; set; }

            public string GitHub { get; set; }

            public string GitLab { get; set; }
        }

        internal class OfferItemQurryResult
        {
            public string Icon { get; set; }

            public int TitleTranslationId { get; set; }

            public int DescriptionTranslationId { get; set; }
        }
    }
}