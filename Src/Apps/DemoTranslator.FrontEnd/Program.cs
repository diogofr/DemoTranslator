using DemoTranslator.FrontEnd.Services;
using Microsoft.Extensions.DependencyInjection;
using DemoTranslator.Abstractions.Services;
using DemoTranslator.FrontEnd.Components;

namespace DemoTranslator.FrontEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddBlazorBootstrap();

            var configuration = builder.Configuration;

            var services = builder.Services;
            var xx = configuration["ApiSettings:GatewayAddress"];

            services.AddHttpClient<ILanguagesService, LanguagesService>();

            services.AddHttpClient<ITranslationsService, TranslationsService>();
            /*
            services.AddHttpClient<ILanguagesService, LanguagesService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));

            services.AddHttpClient<ITranslationService, TranslationService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]));
            */
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (true || !app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            /*
            Task.Delay(TimeSpan.FromSeconds(2)).ContinueWith(_ =>
            {
                var languageService = app.Services.GetService<ILanguagesService>();
                 //var x = languageService.GetSourceLanguagesAsync().GetAwaiter().GetResult();
            });
            */
            await app.RunAsync();
        }
    }
}
