using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Utils
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public LoggingFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LoggingFilter>();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this._logger.LogDebug($"Entered API { context.HttpContext.Request.Path }.", context.ActionArguments);
        }

        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                this._logger.LogError(context.Exception.ToString());
            }
        }


    }
}
