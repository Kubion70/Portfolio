using Portfolio.Core.Database;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Tests.Common.ObjectMothers
{
    public class KnownTechnologyObjectMother
    {
        private IDatabaseWrapper Database { get; }

        private static int counter = 0;

        public KnownTechnologyObjectMother(IDatabaseWrapper database)
        {
            Database = database;
        }

        public async Task<KnownTechnology> CreateAsync(int mainPageConfigurationId)
        {
            counter++;

            var sql = @"
INSERT INTO KnownTechnology (
    Name,
    KnownLevel,
    MainPageConfigurationId
) VALUES (
    @Name,
    @KnownLevel,
    @MainPageConfigurationId
);
SELECT CAST(SCOPE_IDENTITY() as int);
";

            var knownTechnology = new KnownTechnology
            {
                KnownLevel = counter % 2 == 0 ? TechnologyKnownLevel.EnoughToWorkWith : TechnologyKnownLevel.WellKnown,
                Name = counter.ToString(),
                MainPageConfigurationId = mainPageConfigurationId
            };

            knownTechnology.Id = await Database.ExecuteScalarAsync<int>(sql, knownTechnology);

            counter++;

            return knownTechnology;
        }
    }
}
