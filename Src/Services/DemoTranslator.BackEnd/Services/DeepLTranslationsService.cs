using DeepL;
using DemoTranslator.Abstractions.Services;
using DemoTranslator.Abstractions.Models;

namespace DemoTranslator.BackEnd.Services
{
    public class DeepLTranslationsService : ITranslationsService
    {
        private readonly ITranslator handler;

        public DeepLTranslationsService(ITranslator handler)
        {
            this.handler = handler;
        }

        public async Task<TranslationResponse> TranslateAsync(TranslationRequest request)
        {
            var sourceLanguages = await handler.GetSourceLanguagesAsync();
            if (sourceLanguages == null)
            {
                throw new Exception("Unavailable! Try again later!");
            }

            if (!sourceLanguages.Select(i => i.Code).Contains(request.SourceLanguageCode))
            {
                throw new InvalidOperationException($"The language '{request.SourceLanguageCode}' is not supported.");
            }

            var targetLanguages = await handler.GetTargetLanguagesAsync();
            if (targetLanguages == null)
            {
                throw new Exception("Unavailable! Try again later!");
            }

            if (!targetLanguages.Select(i => i.Code).Contains(request.TargetLanguageCode))
            {
                throw new InvalidOperationException($"The language '{request.TargetLanguageCode}' is not supported.");
            }

            var result = await handler.TranslateTextAsync(request.SourceText, request.SourceLanguageCode, request.TargetLanguageCode);
            if (result == null)
            {
                throw new Exception("Unavailable! Try again later!");
            }

            var mapped = new TranslationResponse { TranslatedText = result.Text };
            return mapped;
        }
    }
}
