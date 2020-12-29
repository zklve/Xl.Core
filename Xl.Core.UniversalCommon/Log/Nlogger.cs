using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.UniversalCommon.Log
{
    public class Nlogger : ILog
    {
        private readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        public void WriteLog(string msg)
        {
            _logger.Log(LogLevel.Info, msg);
        }

        public void WriteLog<T>(T t) where T : class, new()
        {

        }

        public void WriteLogAsync(string msg)
        {

        }

        public void WriteLogSync(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
