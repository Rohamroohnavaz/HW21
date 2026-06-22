
using HW21.Service.Exceptions;
using System.Text.Json;
using WebApplication1.WebDTO;

namespace WebApplication1.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Request Processed...");
                Console.WriteLine(ex);
                HandleExceptions(ex, context);
            }
        }

        private void HandleExceptions(Exception exception, HttpContext context)
        {
            switch (exception)
            {
                case ItemNotFoundException ex:
                    context.Response.StatusCode = 404;
                    context.Response.WriteAsync(GenerateResponseBody(ex.Code, ex.Message));
                    break;
                case PermissionDeniedException ex:
                    context.Response.StatusCode = 403;
                    context.Response.WriteAsync(GenerateResponseBody(ex.Code, ex.Message));
                    break;
                case BaseBussinessException ex:
                    context.Response.StatusCode = 400;
                    context.Response.WriteAsync(GenerateResponseBody(ex.Code, ex.Message));
                    break;
                default:
                    context.Response.StatusCode = 500;
                    context.Response.WriteAsync(GenerateResponseBody(
                        "InternalServerError_500" ,"Something Went Wrong!"
                        ));
                    break;
            }
        }

        private string GenerateResponseBody(string code, string message)
        {
            var response = new BaseResponseDto<string>
            {
                Data = null,
                IsSuccess = false,
                Error = new BaseError
                {
                    Code = code,
                    Message = message
                }
            };

            return JsonSerializer.Serialize(response, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}
