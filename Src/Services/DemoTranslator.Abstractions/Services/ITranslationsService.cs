using DemoTranslator.Abstractions.Models;

namespace DemoTranslator.Abstractions.Services
{
    public interface ITranslationsService
    {
        Task<TranslationResponse> TranslateAsync(TranslationRequest request);
    }
}
