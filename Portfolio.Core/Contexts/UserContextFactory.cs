using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Portfolio.Core.Extensions;

namespace Portfolio.Core.Contexts
{
    public class UserContextFactory
    {
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public IUserContext CreateUserContext()
        {
            var culture = HttpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();

            return new UserContext(culture.GetKnownCultureEnum());
        }
    }
}
