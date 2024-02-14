
using DeepL;
using Microsoft.Extensions.Configuration;
using DemoTranslator.Abstractions.Services;
using DemoTranslator.BackEnd.Middlewares;
using DemoTranslator.BackEnd.Services;

namespace DemoTranslator.BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var services = builder.Services;
            var configuration = builder.Configuration;

            var deepLKey = configuration.GetValue<string>("DeepLKey");
            services.AddScoped<ITranslator>(_ => new Translator(deepLKey));
            services.AddScoped<ILanguagesService, DeepLLanguagesService>();
            services.AddScoped<ITranslationsService, DeepLTranslationsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (true) //app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            //app.UseAuthorization();
            //app.UseMiddleware<ApiKeyMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
