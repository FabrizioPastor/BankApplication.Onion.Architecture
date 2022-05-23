using WebAPI.MiddleWares;

namespace WebAPI.Extnesions;

public static class AppExtensions
{
    public static void UseErrorHandlingMiddleWare(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}