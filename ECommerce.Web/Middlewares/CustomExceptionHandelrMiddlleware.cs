using Domain.Exceptions;
using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace ECommerce.Web.Middlewares
{
    public class CustomExceptionHandelrMiddlleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandelrMiddlleware> _logger;
        public CustomExceptionHandelrMiddlleware(RequestDelegate next, ILogger<CustomExceptionHandelrMiddlleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next.Invoke(context);
                // if end point is not found 
                await HandleNorFoundEndPoint(context);
            }
            catch (Exception ex)
            {
                await HandleCatchException(context, ex);
            }

        }

        private async Task HandleCatchException(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "Something Went Wrong");
            //Response Object with content type , status code
            // context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500
            context.Response.ContentType = "application/json";
            var response = new ErrorDetails
            {
                // StatusCode = (int)HttpStatusCode.InternalServerError,
                ErrorMessage = ex.Message
            };

            response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound, // 404
                _ => (int)HttpStatusCode.InternalServerError// 400
            };
            context.Response.StatusCode = response.StatusCode;

            // Return the response as json
            var jsonResult = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResult);
        }

        private static async Task HandleNorFoundEndPoint(HttpContext context)
        {
            if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                context.Response.ContentType = "application/json";

                var response = new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.NotFound, // 404
                    ErrorMessage = $"The requested resource :{context.Request.Path} not found."
                };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
