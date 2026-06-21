
using HW21.Service.Exceptions;

namespace WebApplication1.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
        }

        private void HandleExceptions(Exception exception ,HttpContext context)
        {
            switch (exception)
            {
                case ItemNotFoundException ex:
                    context.Response.StatusCode = 400;
                    break;
            }
        }
    }
}
