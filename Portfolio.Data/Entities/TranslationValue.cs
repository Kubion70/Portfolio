using Dapper.Contrib.Extensions;
using Portfolio.Data.Entities.Abstractions;

namespace Portfolio.Data.Entities
{
    [Table(nameof(TranslationValue))]
    public class TranslationValue : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// References to <see cref="Translation"/>
        /// </summary>
        public int TranslationId { get; set; }

        public string LanguageCountryCode { get; set; }

        public string Value { get; set; }
    }
}
