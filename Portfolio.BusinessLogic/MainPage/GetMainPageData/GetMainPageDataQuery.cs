using Portfolio.Core.QueryAbstractions;
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

            return new GetMainPageDataResult
            {
                Title = queryResult.Title,
                SubTitle = queryResult.SubTitle,
                TopImageUrl = queryResult.TopImageUrl,
                TopDescription = await Translator.GetTranslationAsync(queryResult.TopDescriptionTranslationId, UserContext.Culture),
                AboutMeDescription = await Translator.GetTranslationAsync(queryResult.AboutMeDescriptionTranslationId, UserContext.Culture),
                KnownTechnologies = knownTechnologies
            };
        }

        private const string GET_MAIN_PAGE_DATA_SQL = @"
SELECT TOP 1
    mpc.Id AS MainPageId,
	mpc.Title AS Title,
	mpc.SubTitle AS SubTitle,
	mpc.TopImageUrl AS TopImageUrl,
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

        internal class QueryResultDataSet
        {
            public int MainPageId { get; set; }

            public string Title { get; set; }

            public string SubTitle { get; set; }

            public string TopImageUrl { get; set; }

            public int AboutMeDescriptionTranslationId { get; set; }

            public int TopDescriptionTranslationId { get; set; }
        }
    }
}