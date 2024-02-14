using System.ComponentModel.DataAnnotations;

namespace DemoTranslator.Abstractions.Models
{
    /// <summary>
    /// This model is used when a client application sends a translation request to the server. The SourceText field contains the text to be translated. The SourceLanguage and TargetLanguage fields should contain language codes in BCP47 format, representing the original and target languages, respectively.
    /// </summary>
    public class TranslationRequest
    {
        [Required]
        [StringLength(1000, ErrorMessage = "The source text must be less than 1000 characters.")]
        public string SourceText { get; set; }
        [Required]

        //[RegularExpression(@"[a-z]{2}-[A-Z]{2}", ErrorMessage = "Language code must be in BCP47 format.")]
        [RegularExpression(@"\b[a-zA-Z]{2,3}(-[a-zA-Z]{4})?(-[a-zA-Z]{2}|-[0-9]{3})?\b", ErrorMessage = "Language code must be in BCP47 format.")]
        public string SourceLanguageCode { get; set; }
        [Required]
        //[RegularExpression(@"[a-z]{2}-[A-Z]{2}", ErrorMessage = "Language code must be in BCP47 format.")]
        [RegularExpression(@"\b[a-zA-Z]{2,3}(-[a-zA-Z]{4})?(-[a-zA-Z]{2}|-[0-9]{3})?\b", ErrorMessage = "Language code must be in BCP47 format.")]
        public string TargetLanguageCode { get; set; }
    }
}
