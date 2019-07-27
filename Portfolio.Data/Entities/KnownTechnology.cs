using Dapper.Contrib.Extensions;
using Portfolio.Data.Entities.Abstractions;

namespace Portfolio.Data.Entities
{
    [Table(nameof(KnownTechnology))]
    public class KnownTechnology : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// Reference to <see cref="MainPageConfiguration"/>
        /// </summary>
        public int MainPageConfigurationId { get; set; }

        public TechnologyKnownLevel KnownLevel { get; set; }

        public string Name { get; set; }
    }
}