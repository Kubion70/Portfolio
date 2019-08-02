using Portfolio.Core.QueryAbstractions;
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

            return new GetMainPageDataResult
            {
                Title = queryResult.Title,
                SubTitle = queryResult.SubTitle,
                TopImageUrl = queryResult.TopImageUrl,
                TopDescription = await Translator.GetTranslationAsync(queryResult.TopDescriptionTranslationId, UserContext.Culture),
                AboutMeDescription = await Translator.GetTranslationAsync(queryResult.AboutMeDescriptionTranslationId, UserContext.Culture),
                Phone = queryResult.Phone,
                Email = queryResult.Email,
                KnownTechnologies = knownTechnologies,
                OfferItems = offerItems.Select(async o => new OfferItemResult
                {
                    Icon = o.Icon,
                    Title = await Translator.GetTranslationAsync(o.TitleTranslationId, UserContext.Culture),
                    Description = await Translator.GetTranslationAsync(o.DescriptionTranslationId, UserContext.Culture)
                }).Select(o => o.Result)
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
        }

        internal class OfferItemQurryResult
        {
            public string Icon { get; set; }

            public int TitleTranslationId { get; set; }

            public int DescriptionTranslationId { get; set; }
        }
    }
}