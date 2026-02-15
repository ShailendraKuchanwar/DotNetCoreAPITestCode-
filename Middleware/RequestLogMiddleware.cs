namespace ATMDotNetCoreApp.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLogMiddleware> _logger;

        public RequestLogMiddleware(RequestDelegate next, ILogger<RequestLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("request:{Method} and {url}", context.Request.Method, context.Request.Path);
            await _next(context);
            _logger.LogInformation("response Status: {StatusCode}", context.Response.StatusCode);

        }
    }
}
