namespace MVC.Middlewares;
public class ReqMiddleware(RequestDelegate next, ILogger<ReqMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {

        foreach (var header in context.Request.Headers)
        {
            logger.LogInformation("Header: {Key}: {Value}", header.Key, header.Value);
        }

        logger.LogWarning($"Error warning : hello");

        await next(context);
    }
}