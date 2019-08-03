using Microsoft.AspNetCore.Localization;
using Portfolio.Core.Translations;
using System;
using System.Linq;

namespace Portfolio.Core.Extensions
{
    public static class IRequestCultureFeatureExtensions
    {
        public static KnownCulture GetKnownCultureEnum(this IRequestCultureFeature requestCulture)
        {
            var requestCultureName = requestCulture.RequestCulture.Culture.Name;

            var knwonCultureValues = Enum.GetValues(typeof(KnownCulture)).Cast<KnownCulture>();
            foreach (var cultureEnum in knwonCultureValues)
            {
                if (cultureEnum.GetDisplayName() == requestCultureName)
                    return cultureEnum;
            }

            return KnownCulture.English;
        }
    }
}