using System.ComponentModel.DataAnnotations;

namespace Portfolio.Core.Translations
{
    public enum KnownCulture
    {
        [Display(Name = "en-US")] English = 1,
        [Display(Name = "pl-PL")] Polish = 2
    }
}