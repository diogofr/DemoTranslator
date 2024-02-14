using DeepL.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using DemoTranslator.Abstractions.Services;
using DemoTranslator.Abstractions.Models;
using DemoTranslator.BackEnd.Controllers;
using DemoTranslator.BackEnd.Services;

namespace BackEndService.xunitTests
{
    public class TranslationsControllerTests
    {
        [Fact]
        public async Task Translate_ReturnsBadRequest_ForInvalidModelState()
        {
            // Arrange
            var mockService = new Mock<ITranslationsService>();
            var controller = new TranslationsController(mockService.Object);
            controller.ModelState.AddModelError("SourceText", "Required");

            var request = new TranslationRequest(); // Intentionally invalid

            // Act
            var result = await controller.Translate(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }

    public class TranslationServiceTests
    {
        public DeepL.Model.SourceLanguage[] GetMockedSourceLanguages()
        {
            return new SourceLanguage[]
            {
                new SourceLanguage("en", "English"),
                new SourceLanguage("fr", "French"),
                new SourceLanguage("de", "German"),
            };
        }

        public DeepL.Model.TargetLanguage[] GetMockedTargetLanguages()
        {
            return new TargetLanguage[]
            {
                new TargetLanguage("en-GB", "English (British)", false),
                new TargetLanguage("en-US", "English (American)", false),
                new TargetLanguage("fr", "French", false),
                new TargetLanguage("de", "German", false),
            };
        }

        [Fact]
        public async Task TranslateAsync_ThrowsException_ForUnsupportedLanguage()
        {
            // Arrange
            var mockDeepL = new Mock<DeepL.ITranslator>();
            mockDeepL
            .Setup(p => p.GetTargetLanguagesAsync(CancellationToken.None))
            .ReturnsAsync(GetMockedTargetLanguages());
            mockDeepL
            .Setup(p => p.GetSourceLanguagesAsync(CancellationToken.None))
            .ReturnsAsync(GetMockedSourceLanguages());

            var unsupportedLanguageRequest = new TranslationRequest
            {
                SourceText = "Hello",
                SourceLanguageCode = "en",
                TargetLanguageCode = "xx-XX" // Assuming this is an unsupported language code
            };

            var service = new DeepLTranslationsService(mockDeepL.Object); // Assume TranslationService has a way to determine supported languages

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.TranslateAsync(unsupportedLanguageRequest));
        }
    }



    public class UnitTest1
    {
        public class TranslationServiceTests
        {
            [Fact]
            public async Task TranslateText_ShouldReturnTranslatedText()
            {
                // Arrange

                var translationProviderMock = new Mock<ITranslationsService>();

                translationProviderMock
                .Setup(p => p.TranslateAsync(It.Is<TranslationRequest>(o => o.SourceLanguageCode == "en" && o.TargetLanguageCode == "fr" && o.SourceText == "Hello")))
                .ReturnsAsync(new TranslationResponse { TranslatedText = "Bonjour" });

                var translationService = translationProviderMock.Object;
                //var translationService = new TranslationService(translationProviderMock.Object);

                // Act
                var response = await translationService.TranslateAsync(new TranslationRequest { SourceLanguageCode = "en", TargetLanguageCode = "fr", SourceText = "Hello" });
                var translatedText = response.TranslatedText;
                // Assert
                Assert.Equal("Bonjour", translatedText);
            }
        }
    }
}