namespace APIExam.Middleware
{
    public class ErrorExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorExceptionHandling> _logger;

        public ErrorExceptionHandling(RequestDelegate next, ILogger<ErrorExceptionHandling> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value?.ToLower() ?? "";

            // Let preflight requests pass through immediately
            if (string.Equals(context.Request.Method, "OPTIONS", StringComparison.OrdinalIgnoreCase))
            {
                // Optionally you can short-circuit with 200 here; but CORS middleware already handles it if registered earlier
                await _next(context);
                return;
            }

            // Allow the login API (public endpoint)
            if (path.Contains("/api/login/login"))
            {
                await _next(context);
                return;
            }

            if (path.Contains("/api/dwnldexmfrm/downloadexamform"))
            {
                await _next(context);
                return;
            }

            if (path.Contains("/api/examform/exam-list"))
            {
                await _next(context);
                return;
            }
            if (path.Contains("/api/ExamForm/GetStudentExamList"))
            {
                await _next(context);
                return;
            }
            //if (path.Contains("/api/dwnldregform/dwnldregform"))
            //{
            //    await _next(context);
            //    return;
            //}


            // ...existing auth header checks...
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrWhiteSpace(token))
            {
                _logger.LogWarning("Unauthorized access attempt on {URL}", context.Request.Path);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized access. Missing token.");
                return;
            }

            await _next(context);
        }


    }
}