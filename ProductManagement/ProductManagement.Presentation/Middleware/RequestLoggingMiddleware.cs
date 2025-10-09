using System.Diagnostics;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Presentation.Middleware
{
    public class RequestLoggingMiddleware
    {
        private RequestDelegate _next;
        private ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            var user = context.User;
            var username = user?.Identity?.IsAuthenticated == true ? user.Identity.Name : "Anonymous";

            _logger.LogInformation(
                "Incomming Request: {Method} {Path} | User: {Username}",
                context.Request.Method,
                context.Request.Path,
                username);
            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation(
                    "Finished Request: {Method} {Path} | User: {Username} | Status: {StatusCode} | Duration: {Duration}ms",
                    context.Request.Method,
                    context.Request.Path,
                    username,
                    context.Response.StatusCode,
                    stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
