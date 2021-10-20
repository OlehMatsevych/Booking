using Booking.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Booking.API.Middleware
{
    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;
        private readonly RequestDelegate _next;
        public ExceptionHandler(ILogger<ExceptionHandler> logger, RequestDelegate next) 
        {
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleException(context,ex);
            }
        }

        public async Task HandleException(HttpContext context, Exception error)
        {
            _logger.LogError(error.Message);
            var response = context.Response;
            response.ContentType = "application/json";
            switch (error)
            {
                case ArgumentException _:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException _:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case InvalidOperationException _:
                    response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                    break;
                case UserNotFoundException _:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
            }
            //TODO: OPERATION STATUS
            var result = JsonSerializer.Serialize(new { message = error.Message });
            await response.WriteAsync(result);
        }

    }
}
