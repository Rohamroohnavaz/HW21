using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class LoggingActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("[Logging Action Filter] Response is ready .");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("[Logging Action Filter] Request Came .");
        }
    }
}
