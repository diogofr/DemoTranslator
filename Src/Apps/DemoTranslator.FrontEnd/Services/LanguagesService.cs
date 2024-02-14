using DemoTranslator.FrontEnd.Extensions;
using Microsoft.Extensions.Configuration;
using DemoTranslator.Abstractions.Services;
using DemoTranslator.Abstractions.Models;

namespace DemoTranslator.FrontEnd.Services
{
    public class LanguagesService : ILanguagesService
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly HttpClient _client;

        public LanguagesService(IConfiguration configuration, HttpClient client)
        {
            _baseUrl = configuration.GetValue<string>("LanguagesBaseUrl");
            _apiKey = configuration.GetValue<string>("ApiKey");
            if (_apiKey != null)
            {
                client.DefaultRequestHeaders.Add("ApiKey", _apiKey);
            }
            _client = client;
        }

        public async Task<List<Language>> GetAvailableLanguagesAsync()
        {
            var response = await _client.GetAsync($"{_baseUrl}GetAvailableLanguagesAsync");
            return await response.ReadContentAs<List<Language>>();
        }

        public async Task<List<Language>> GetSourceLanguagesAsync()
        {
            var response = await _client.GetAsync($"{_baseUrl}GetSourceLanguages");
            return await response.ReadContentAs<List<Language>>();
        }

        public async Task<List<Language>> GetTargetLanguagesAsync()
        {
            var response = await _client.GetAsync($"{_baseUrl}GetTargetLanguages");
            return await response.ReadContentAs<List<Language>>();
        }
    }
}
