using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ServiceApp.Middlewares;

namespace ServiceApp.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware( this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddlewareHandler>();
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
