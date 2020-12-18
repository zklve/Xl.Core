using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Xl.Core.UniversalCommon.Configs;
using Xl.Core.UniversalCommon.Helper;

namespace Xl.Core.DbSession.DataBase
{
    public class MySqlDb : BaseDb
    {

        public MySqlDb()
        {

        }

        public MySqlDb(bool isReload) : base(isReload)
        {

        }

        #region Idb

        /// <summary>
        /// 获取数据库连接。
        /// </summary>
        /// <returns></returns>
        public override System.Data.IDbConnection GetDbConnection()
        {
            return new MySqlConnection("Server=" + this.Host + ";" + (this.Port != 3306 ? "Port=" + this.Port + ";" : "") + "Database=" + this.ServiceName + ";Uid=" + this.UserName + ";pwd=" + this.Password + ";Connect Timeout=10;" + (this.CommandTimeout.HasValue ? "Default Command Timeout=" + this.CommandTimeout.Value + ";" : "") + (this.ConnectionLifetime.HasValue ? "Connection Lifetime=" + this.ConnectionLifetime.Value + ";" : ""));
        }

        public override IDbConnection GetDbConnection(bool isReadOnly)
        {
            return new MySqlConnection("Server=" + this.Host + ";" + (this.Port != 3306 ? "Port=" + this.Port + ";" : "") + "Database=" + this.ServiceName + ";Uid=" + this.UserName + ";pwd=" + this.Password + ";Connect Timeout=10;" + (this.CommandTimeout.HasValue ? "Default Command Timeout=" + this.CommandTimeout.Value + ";" : "") + (this.ConnectionLifetime.HasValue ? "Connection Lifetime=" + this.ConnectionLifetime.Value + ";" : ""));
        }

        public override IDbConnection GetDbConnectionWithPool()
        {
            return new MySqlConnection("Server=" + this.Host + ";" + (this.Port != 3306 ? "Port=" + this.Port + ";" : "") + "Database=" + this.ServiceName + ";Uid=" + this.UserName + ";pwd=" + this.Password + ";Connect Timeout=10;" + (this.CommandTimeout.HasValue ? "Default Command Timeout=" + this.CommandTimeout.Value + ";" : "") + (this.ConnectionLifetime.HasValue ? "Connection Lifetime=" + this.ConnectionLifetime.Value + ";" : ""));
        }

        #endregion
    }
}
