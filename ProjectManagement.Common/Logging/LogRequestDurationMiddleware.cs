using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ProjectManagement.Common.Logging
{
    internal class LogRequestDurationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogRequestDurationMiddleware> _logger;

        public LogRequestDurationMiddleware(ILogger<LogRequestDurationMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            _logger.LogInformation("Request {Method} {Path} executed in {Duration}ms", context.Request.Method, context.Request.Path, stopwatch.ElapsedMilliseconds);
        }
    }
}
