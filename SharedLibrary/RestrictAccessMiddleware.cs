using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public class RestrictAccessMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
           var referrer = context.Request.Headers["Referrer"].FirstOrDefault();
            if (string.IsNullOrEmpty(referrer)) { 
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access denied. Referrer header is missing.");
                return;
            } else { 
                await next(context);
            }
        }
    }
}
