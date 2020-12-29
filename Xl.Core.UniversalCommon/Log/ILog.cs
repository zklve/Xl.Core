using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.UniversalCommon.Log
{
    /// <summary>
    /// 日志 
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 一般日志
        /// </summary>
        /// <param name="msg"></param>
        void WriteLog(string msg);

        /// <summary>
        /// 异步写入日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void WriteLogSync(string msg);

        /// <summary>
        /// Json格式日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void WriteLog<T>(T t) where T : class, new();




    }
}
