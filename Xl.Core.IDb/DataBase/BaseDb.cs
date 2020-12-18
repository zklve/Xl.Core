using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Xl.Core.UniversalCommon.Configs;
using Xl.Core.UniversalCommon.Helper;

namespace Xl.Core.DbSession.DataBase
{
    public abstract class BaseDb : IDb
    {
        public static DbConfig m_Config = ConfigHelper.Get<DbConfig>("DbConfig");

        public BaseDb()
        {
            m_Host = m_Config.Host;
            m_Port = m_Config.Port;
            m_ServiceName = m_Config.ServiceName;
            m_UserName = m_Config.UserName;
            m_Password = m_Config.Password;
            m_CommandTimeout = m_Config.CommandTimeout;
            m_ConnectionLifetime = m_Config.ConnectionLifetime;
        }

        /// <summary>
        /// 是否重新加载配置
        /// </summary>
        /// <param name="isReloadConfig"></param>
        public BaseDb(bool isReloadConfig)
        {
            if (isReloadConfig)
            {
                var config = ConfigHelper.Get<DbConfig>("DbConfig");
                m_Host = config.Host;
                m_Port = config.Port;
                m_ServiceName = config.ServiceName;
                m_UserName = config.UserName;
                m_Password = config.Password;
                m_CommandTimeout = config.CommandTimeout;
                m_ConnectionLifetime = config.ConnectionLifetime;
            }
        }


        private string m_Host = "";
        /// <summary>
        /// 主机名或 IP 地址。
        /// </summary>
        public string Host
        {
            get { return this.m_Host; }
            set { this.m_Host = value; }
        }

        private int m_Port = 3306;
        /// <summary>
        /// 主机端口。默认为 3306。
        /// </summary>
        public int Port
        {
            get { return this.m_Port; }
            set { this.m_Port = value; }
        }

        private string m_ServiceName = "";
        /// <summary>
        /// MySql 服务名。
        /// </summary>
        public string ServiceName
        {
            get { return this.m_ServiceName; }
            set { this.m_ServiceName = value; }
        }

        private string m_UserName = "";
        /// <summary>
        /// 登录用户名。
        /// </summary>
        public string UserName
        {
            get { return this.m_UserName; }
            set { this.m_UserName = value; }
        }

        private string m_Password = "";
        /// <summary>
        /// 登录密码。
        /// </summary>
        public string Password
        {
            get { return this.m_Password; }
            set { this.m_Password = value; }
        }

        private int? m_CommandTimeout;
        /// <summary>
        /// 命令超时
        /// </summary>
        public int? CommandTimeout
        {
            get { return this.m_CommandTimeout; }
            set { this.m_CommandTimeout = value; }
        }

        private int? m_ConnectionLifetime;
        /// <summary>
        /// 连接寿命
        /// </summary>
        public int? ConnectionLifetime
        {
            get { return this.m_ConnectionLifetime; }
            set { this.m_ConnectionLifetime = value; }
        }


        #region  IDB接口
        public abstract IDbConnection GetDbConnection();


        public abstract IDbConnection GetDbConnection(bool isReadOnly);


        public abstract IDbConnection GetDbConnectionWithPool();
     

        public string GetAvgColumn(string columnName)
        {
            throw new NotImplementedException();
        }

        public string GetColumnName(string columnCode)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetDataReader(DbConnection dbConnection, int pageSize, string selectColumns, string tableNames, string where, string order_Tablename)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetDataReader(DbConnection dbConnection, int pageSize, int pageNum, string selectColumns, string tableNames, string where, string order_Tablename, string order_Reverse, string order)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetDataReader(DbConnection dbConnection, int pageSize, int recordsetCount, string selectColumns, string tableNames, string where, string order_TablenameReverse, string order)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetDataReader(DbConnection dbConnection, int pageSize, string selectColumns, string tableNames, string where, string order_Tablename, int commandTimeout, params IDbDataParameter[] dataParameters)
        {
            throw new NotImplementedException();
        }

     

        public IDbDataParameter GetDbDataParameter(string parameterName, object value)
        {
            throw new NotImplementedException();
        }

        public string GetDbDataParameterValueName(string parameterName)
        {
            throw new NotImplementedException();
        }

        public string GetDbDataParameterValueNameByDateTime(string parameterName)
        {
            throw new NotImplementedException();
        }

        public string GetOrderByColumn(string columnName, bool isDesc)
        {
            throw new NotImplementedException();
        }

        public bool TableIsExist(string tableName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
