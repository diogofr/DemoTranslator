using DemoTranslator.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTranslator.Abstractions.Services
{
    public interface ILanguagesService
    {
        Task<List<Language>> GetSourceLanguagesAsync();
        Task<List<Language>> GetTargetLanguagesAsync();

        Task<List<Language>> GetAvailableLanguagesAsync();
    }
}
