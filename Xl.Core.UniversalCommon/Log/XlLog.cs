using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xl.Core.UniversalCommon.Log;

namespace Xl.Core.UniversalCommon.Log
{
    public class XlLog : ILog
    {
        private static readonly object m_objLog = new object();

        private int m_LogLastDay = 0;
        private System.IO.StreamWriter m_swLog;
        private string m_RootDirectory = AppContext.BaseDirectory + "LogInfo";

        private BlockingCollection<string> msgList = new BlockingCollection<string>();

        public XlLog()
        {
            Task.Run(()=>
            {
                while (true)
                {
                    var msg = msgList.Take();
                    WriteLog(msg);
                }
            });
            
        }

        public void WriteLog(string log)
        {
            if (System.Threading.Monitor.TryEnter(m_objLog, 5000))
            {
                try
                {
                    if (!Directory.Exists(m_RootDirectory))
                    {
                        Directory.CreateDirectory(m_RootDirectory);
                    }

                    if (m_LogLastDay != DateTime.Today.Day)
                    {
                        if (this.m_swLog != null)
                        {
                            this.m_swLog.Close();
                        }
                        this.m_swLog = new System.IO.StreamWriter(Path.Combine(this.m_RootDirectory, GetIntDate() + "_Log.txt"), true, System.Text.Encoding.Default);
                        m_LogLastDay = DateTime.Today.Day;
                    }
                    this.m_swLog.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + " " + log);
                    this.m_swLog.Flush();
                }
                catch { }
                finally
                {
                    System.Threading.Monitor.Exit(m_objLog);
                }
            }
        }

        public void WriteLog<T>(T t) where T : class, new()
        {

        }

        /// <summary>
        /// 获取系统整型日期值
        /// </summary>
        /// <returns></returns>
        public static int GetIntDate()
        {
            DateTime dtmValue = DateTime.Today;
            return dtmValue.Year * 10000 + dtmValue.Month * 100 + dtmValue.Day;
        }

        public void WriteLogSync(string msg)
        {
            msgList.TryAdd(msg);
        }
    }
}
