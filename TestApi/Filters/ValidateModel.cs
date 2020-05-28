using Microsoft.AspNetCore.Mvc.Filters;

namespace TestApi.Filters
{
    public class ValidateModel : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}