namespace DemoTranslator.Abstractions.Models
{
    /// <summary>
    /// This simple model might be used, for example, in an endpoint that lists available languages. Each Language instance represents a language supported by the translation service, including a user-friendly Name and a Code that conforms to the BCP47 format.
    /// </summary>
    public class Language
    {
        public string Name { get; set; }
        public string Code { get; set; } // BCP47 format
    }
}
