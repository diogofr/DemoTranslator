using DemoTranslator.FrontEnd.Extensions;
using DemoTranslator.Abstractions.Services;
using DemoTranslator.Abstractions.Models;

namespace DemoTranslator.FrontEnd.Services
{
    public class TranslationsService : ITranslationsService
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly HttpClient _client;

        public TranslationsService(IConfiguration configuration, HttpClient client)
        {
            _baseUrl = configuration.GetValue<string>("TranslationsBaseUrl");
            _apiKey = configuration.GetValue<string>("ApiKey");
            if (_apiKey != null)
            {
                client.DefaultRequestHeaders.Add("ApiKey", _apiKey);
            }
            _client = client;
        }

        public async Task<TranslationResponse> TranslateAsync(TranslationRequest request)
        {
            var response = await _client.PostAsJson($"{_baseUrl}translate", request);
            if (response == null)
            {
                throw new Exception("Something went wrong when calling api.");
            }

            return await response.ReadContentAs<TranslationResponse>();
        }
    }
}
