using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xl.Core.UniversalCommon.Log;

namespace Xl.Core.API.Filters
{
    public class LogTraceAttribute : ActionFilterAttribute
    {
        private  static ILog _log = new XlLog();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _log.WriteLog("接口名称:"+ context.HttpContext.Request.Method);

        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _log.WriteLog("接口名称:" + context.HttpContext.Response.Body);
        }

    }
}
