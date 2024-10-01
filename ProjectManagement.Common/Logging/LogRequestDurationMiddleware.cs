using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using SerilogTimings.Extensions;

namespace ProjectManagement.Common.Logging;

internal class LogRequestDurationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public LogRequestDurationMiddleware(ILogger logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var operation = _logger
            .OperationAt(LogEventLevel.Information, warningThreshold: TimeSpan.FromMilliseconds(500))
            .Begin("{RequestMethod} {RequestName}", context.Request.Method.ToUpperInvariant(), context.Request.Path);

        await _next(context);

        operation.Complete();
    }
}