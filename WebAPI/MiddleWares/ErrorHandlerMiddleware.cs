namespace WebAPI.MiddleWares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext content)
    {
        try
        {
            await _next(content);
        }
        catch (Exception error)
        {
            switch (error)
            {
                case Application.Exceptions.ApiExceptions:
                    
                    break;
            }
        }
    }
}