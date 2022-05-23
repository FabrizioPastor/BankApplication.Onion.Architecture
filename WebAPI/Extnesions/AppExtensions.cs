using WebAPI.MiddleWares;

namespace WebAPI.Extnesions;

public static class AppExtensions
{
    public static void UseErrorHalndlingMiddleWare(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}