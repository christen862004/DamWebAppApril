using Microsoft.AspNetCore.Mvc.Filters;

namespace DamWebAppApril.Filtters
{
    public class CustomFilterAttribute : Attribute,IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //logic

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //empty
        }
    }
}
