using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ZipApi
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _request;
        public ExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            string message;
            if (ex is DbUpdateException)
                message = ex.InnerException.Message;
            else
                message = ex.Message;
            var result = JsonConvert.SerializeObject(new { error = message });
            await context.Response.WriteAsync(result).ConfigureAwait(false);
        }

    }
}
