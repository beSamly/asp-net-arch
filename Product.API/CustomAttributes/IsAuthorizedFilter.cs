using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Product.API.CustomAttributes
{
    public class IsAuthorizedFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            HttpContext httpContext = context.HttpContext;
            Console.WriteLine("Do something before the action executes.");
            throw new UserNotAuthenticated("user not authorized");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            Console.WriteLine("Do something after the action executes.");
        }
    }
}