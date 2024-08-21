using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace OTS.Common.ErrorHandle
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    AppException => (int)HttpStatusCode.BadRequest,// custom application error
                    MissingFieldException => (int)HttpStatusCode.BadRequest,// missing field error
                    PasswordException => (int)HttpStatusCode.BadRequest,// missing field error
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,// not found error
                    DuplicateException => (int)HttpStatusCode.Conflict,// duplicatte error
                    _ => (int)HttpStatusCode.InternalServerError,// unhandled error
                };
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
