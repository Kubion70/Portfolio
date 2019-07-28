using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Portfolio.Core.Extensions;
using Portfolio.Core.Translations;

namespace Portfolio.Core.Contexts
{
    public class UserContext : IUserContext
    {
        public KnownCulture Culture { get; }

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            var culture = httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();

            Culture = culture.GetKnownCultureEnum();
        }
    }
}