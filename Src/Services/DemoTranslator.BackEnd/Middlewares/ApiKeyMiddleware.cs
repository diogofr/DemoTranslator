﻿namespace DemoTranslator.BackEnd.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly string apiKey;
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(IConfiguration configuration, RequestDelegate next)
        {
            apiKey = configuration.GetValue<string>("ApiKey");
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {


            if (!context.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided");
                return;
            }

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }

            await _next(context);
        }
    }
}
