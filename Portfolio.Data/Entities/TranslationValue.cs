using Dapper.Contrib.Extensions;

namespace Portfolio.Data.Entities
{
    [Table(nameof(TranslationValue))]
    public class TranslationValue
    {
        [Key]
        /// <summary>
        /// References to <see cref="Translation"/>
        /// </summary>
        public int TranslationId { get; set; }

        [Key]
        public string LanguageCountryCode { get; set; }

        public string Value { get; set; }
    }
}