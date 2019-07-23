using Dapper.Contrib.Extensions;
using Portfolio.Data.Entities.Abstractions;

namespace Portfolio.Data.Entities
{
    [Table(nameof(MainPageConfiguration))]
    public class MainPageConfiguration : IEntity<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        /// <summary>
        /// Reference to <see cref="Translation"/>
        /// </summary>
        public int TopDescriptionTranslationId { get; set; }

        /// <summary>
        /// Reference to <see cref="Translation"/>
        /// </summary>
        public int AboutMeDescriptionTranslationId { get; set; }
    }
}
