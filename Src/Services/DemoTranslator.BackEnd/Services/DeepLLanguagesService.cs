using DeepL;
using DemoTranslator.Abstractions.Services;
using DemoTranslator.Abstractions.Models;

namespace DemoTranslator.BackEnd.Services
{
    public class DeepLLanguagesService : ILanguagesService
    {
        private readonly ITranslator handler;

        public DeepLLanguagesService(ITranslator handler)
        {
            this.handler = handler;
        }

        public async Task<List<Language>> GetSourceLanguagesAsync()
        {
            var filteredLanguages = await handler.GetSourceLanguagesAsync();
            var mappedLanguages = filteredLanguages.Select(i => new Language { Name = i.Name, Code = i.Code }).ToList();

            return mappedLanguages;
        }

        public async Task<List<Language>> GetTargetLanguagesAsync()
        {
            var filteredLanguages = await handler.GetTargetLanguagesAsync();
            var mappedLanguages = filteredLanguages.Select(i => new Language { Name = i.Name, Code = i.Code }).ToList();

            return mappedLanguages;
        }

        public async Task<List<Language>> GetAvailableLanguagesAsync()
        {
            var sourceLanguages = await handler.GetSourceLanguagesAsync();
            var targetLanguages = await handler.GetTargetLanguagesAsync();
            var sourceLanguageCodes = sourceLanguages.Select(i2 => i2.Code);
            var filteredLanguages = targetLanguages.Where(i => sourceLanguageCodes.Contains(i.Code)).ToList();
            var mappedLanguages = filteredLanguages.Select(i => new Language { Name = i.Name, Code = i.Code }).ToList();

            return mappedLanguages;
        }
    }
}
