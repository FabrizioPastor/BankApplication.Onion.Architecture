using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Extnesions;

public static class ServiceExtensions
{
    public static void AddApiVersoningExtension(this IServiceCollection services)
    {
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });
    }
}