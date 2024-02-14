# CONTEXT

Your task is to construct a simple machine translation tool capable of translating sentences among three popular languages. A sophisticated UI design is not necessary; instead, focus on delivering a minimal, clean solution following best practices. As a senior backend developer, you'll be expected to articulate your solution intuitively and in an organized manner during the interview.

This evaluation encompasses two key areas:

1. **Technical Skills:**
   Demonstrated through the creation of a simple yet clean technical solution.

2. **Communication Skills:**
   Evaluated by how effectively you walk us through the code and communicate about the solution.

# REQUIREMENTS

## FRONTEND SERVICE

The user should be able to:

- Set the source and target language to English, German, or French.
- Enter text for translation in the source text area.
- Trigger translation via a button.
- Visualize the translation in the target translation area.
- Use any technology you find suitable (e.g., Vue.js, Blazor, Angular, React).

## BACKEND SERVICE

The REST API should:

- Be written in C# (preferably using .NET 6+).
- Include unit testing.
- Have basic authentication.
- Include input validation and protection.
- Allow a configurable list of languages (Using BCP47 format).
- Provide an endpoint to retrieve available languages.
- Provide an endpoint to translate text to a given language.
- Expose API documentation with OpenAPI (e.g., Swagger UI).
- Recommend using NuGet for translation logic (e.g., DeepL, Google Translate).

