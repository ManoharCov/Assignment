
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
namespace MVC_Assignment.Filters
{
  
        public class AboutActionFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                File.AppendAllText(
                    "actionlog.txt",
                    $"About action executed at {DateTime.Now}\n"
                );
            }
        }

}
