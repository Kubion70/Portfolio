using Portfolio.Core.Translations;

namespace Portfolio.Core.Contexts
{
    public class UserContext : IUserContext
    {
        public KnownCulture Culture { get; }

        public UserContext(KnownCulture culture)
        {
            Culture = culture;
        }
    }
}