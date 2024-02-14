using Microsoft.AspNetCore.Mvc;
using DemoTranslator.Abstractions.Services;
using DemoTranslator.Abstractions.Models;

namespace DemoTranslator.BackEnd.Controllers
{

    [ApiController]
    //[Route("[controller]")]
    [Route("api/[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguagesService service;

        public LanguagesController(ILanguagesService service)
        {
            this.service = service;
        }

        [HttpGet("GetSourceLanguages")]
        public async Task<IEnumerable<Language>> GetSourceLanguages()
        {
            var result = await service.GetSourceLanguagesAsync();
            return result;
            //return Ok(_languages);
        }

        [HttpGet("GetTargetLanguages")]
        public async Task<IEnumerable<Language>> GetTargetLanguagesAsync()
        {
            var result = await service.GetTargetLanguagesAsync();
            return result;
            //return Ok(_languages);
        }

        [HttpGet("GetAvailableLanguages")]
        public async Task<IEnumerable<Language>> GetAvailableLanguagesAsync()
        {
            var result = await service.GetAvailableLanguagesAsync();
            return result;
            //return Ok(_languages);
        }
    }
}
