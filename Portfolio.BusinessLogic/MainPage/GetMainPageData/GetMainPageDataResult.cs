using Portfolio.Data.Entities;
using System.Collections.Generic;

namespace Portfolio.BusinessLogic.MainPage.GetMainPageData
{
    public class GetMainPageDataResult
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string TopImageUrl { get; set; }

        public string AboutMeDescription { get; set; }

        public string TopDescription { get; set; }

        public IEnumerable<KnownTechnologyResult> KnownTechnologies { get; set; }

        public class KnownTechnologyResult
        {
            public TechnologyKnownLevel KnownLevel { get; set; }

            public string Name { get; set; }
        }
    }
}