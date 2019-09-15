using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Eventures.Infrastructure.Filters
{
    public class AdminActivityLoggerFilter : IActionFilter
    {
        private readonly ILogger<AdminActivityLoggerFilter> logger;

        public AdminActivityLoggerFilter(ILogger<AdminActivityLoggerFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //logger.LogInformation(context.)
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Not needed        
        }
    }
}