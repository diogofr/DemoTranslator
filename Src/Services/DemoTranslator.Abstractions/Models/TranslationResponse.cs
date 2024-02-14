namespace DemoTranslator.Abstractions.Models
{
    /// <summary>
    /// Upon successful translation, the service uses this model to send back the translated text encapsulated in the TranslatedText field.
    /// </summary>
    public class TranslationResponse
    {
        public string TranslatedText { get; set; }
    }
}
