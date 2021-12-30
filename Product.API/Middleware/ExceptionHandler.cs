using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Product.API.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException customException)
            {
                var response = context.Response;
                await response.WriteAsync("this is custom exception");
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                await response.WriteAsync("Damm unhanlded exception");

                // switch (error)
                // {
                //     case AppException e:
                //         // custom application error
                //         response.StatusCode = (int) HttpStatusCode.BadRequest;
                //         break;
                //     case KeyNotFoundException e:
                //         // not found error
                //         response.StatusCode = (int) HttpStatusCode.NotFound;
                //         break;
                //     default:
                //         // unhandled error
                //         response.StatusCode = (int) HttpStatusCode.InternalServerError;
                //         break;
                // }
                //
                // var result = JsonSerializer.Serialize(new {message = error?.Message});
            }
        }
    }
}