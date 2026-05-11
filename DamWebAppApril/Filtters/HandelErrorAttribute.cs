using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DamWebAppApril.Filtters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult result=new ContentResult();
            //result.Content = context.Exception.Message;
            ViewResult result=new ViewResult();
            result.ViewName = "Error";//share
            context.Result = result;//json,view,content
        }
    }
}
