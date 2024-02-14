using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DemoTranslator.Abstractions.Services;
using DemoTranslator.Abstractions.Models;

namespace DemoTranslator.BackEnd.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TranslationsController : ControllerBase
    {
        private readonly ITranslationsService _translationService;

        public TranslationsController(ITranslationsService translationService)
        {
            _translationService = translationService;
        }

        [HttpPost("Translate")]
        public async Task<IActionResult> Translate([FromBody] TranslationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _translationService.TranslateAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
