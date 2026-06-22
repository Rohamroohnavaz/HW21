
namespace WebApplication1.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine($"[Incoming Request] {context.Request.Method}  {context.Request.Path}");

            await next(context);

            Console.WriteLine($"[Outgoing Response] {context.Request.Method}  {context.Request.Path}");
        }
    }
}
