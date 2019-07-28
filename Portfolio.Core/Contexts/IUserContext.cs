using Portfolio.Core.Translations;

namespace Portfolio.Core.Contexts
{
    public interface IUserContext
    {
        KnownCulture Culture { get; }
    }
}