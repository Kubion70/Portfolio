using Dapper.Contrib.Extensions;
using Portfolio.Data.Entities.Abstractions;

namespace Portfolio.Data.Entities
{
    [Table(nameof(OfferItem))]
    public class OfferItem : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// Reference to <see cref="MainPageConfiguration"/>
        /// </summary>
        public int MainPageConfigurationId { get; set; }

        public string Icon { get; set; }

        /// <summary>
        /// Reference to <see cref="Translation"/>
        /// </summary>
        public int TitleTranslationId { get; set; }

        /// <summary>
        /// Reference to <see cref="Translation"/>
        /// </summary>
        public int DescriptionTranslationId { get; set; }
    }
}