using System.Data;
using System.Threading.Tasks;

namespace Portfolio.Core.Translations
{
    public interface ITranslator
    {
        Task<string> GetTranslationAsync(int translationId, KnownCulture culture, IDbTransaction transaction = null);

        Task<int> CreateTranslationAsync(string translationValue, KnownCulture culture, int? translationId = null, IDbTransaction transaction = null);
    }
}