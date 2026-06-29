using HW21.Service.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1
{
    public class RequestModelFilter : Attribute, IActionFilter
    {
        public RequestModelFilter()
        {
            Console.WriteLine("Filter ");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var error = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                throw new BaseBussinessException(string.Join("," ,error), "ServiceError_400");
            }
        }
    }
}
