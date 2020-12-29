using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Xl.Core.API.Filters
{
    /// <summary>
    /// autofac方式
    /// </summary>
    public class AuthFilter : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //MethodInfo methodInfo = invocation.MethodInvocationTarget;
            //if (methodInfo == null) methodInfo = invocation.Method;
            //string methodName = invocation.InvocationTarget.ToString() + "." + invocation.Method.Name;
            //Log4NetHelper.Info($"before start {methodName}", typeof(AopTest));
            //invocation.Proceed();
            //Log4NetHelper.Info($"finish start {methodName}", typeof(AopTest));

        }
    }
}
