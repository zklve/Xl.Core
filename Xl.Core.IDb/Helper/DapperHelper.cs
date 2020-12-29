using Autofac;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Xl.Core.DbSession.DataBase;
using Xl.Core.UniversalCommon;
using Xl.Core.UniversalCommon.Configs;
using Xl.Core.UniversalCommon.Helper;

namespace Xl.Core.DbSession.Helper
{
    public class DapperHelper
    {
        public static IDb _Db;

        static DapperHelper()
        {
            if (_Db == null)
            {
                using (var scope = Application.Container.BeginLifetimeScope())
                {
                    _Db = scope.Resolve<IDb>();
                }
            }
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sql">查询的sql</param>
        /// <param name="param">替换参数</param>
        /// <returns></returns>
        public static List<T> Query<T>(string sql, object param) where T : class, new()
        {
            using (var conn = _Db.GetDbConnection())
            {
                return conn.Query<T>(sql, param).ToList();
            }
        }

        /// <summary>
        /// 查询第一个数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QueryFirst<T>(string sql, object param) where T : class, new()
        {
            using (var conn = _Db.GetDbConnection())
            {
                return conn.QueryFirst<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询第一个数据没有返回默认值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QueryFirstOrDefault<T>(string sql, object param) where T : class, new()
        {
            using (var conn = _Db.GetDbConnection())
            {
                return conn.QueryFirstOrDefault<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QuerySingle<T>(string sql, object param) where T : class, new()
        {
            using (var conn = _Db.GetDbConnection())
            {
                return conn.QuerySingle<T>(sql, param);
            }
        }

        /// <summary>
        /// 查询单条数据没有返回默认值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T QuerySingleOrDefault<T>(string sql, object param) where T : class, new()
        {
            using (var conn = _Db.GetDbConnection())
            {
                return conn.QuerySingleOrDefault<T>(sql, param);
            }
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int Execute(string sql, object param)
        {
            using (var conn = _Db.GetDbConnection())
            {
                return conn.Execute(sql, param);
            }
        }

        /// <summary>
        /// Reader获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(string sql, object param)
        {
            using (var conn = _Db.GetDbConnection())
            {
                return conn.ExecuteReader(sql, param);
            }
        }

        /// <summary>
        /// Scalar获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, object param)
        {
            using (var conn = _Db.GetDbConnection())
            {
                return conn.ExecuteScalar(sql, param);
            }
        }

        /// <summary>
        /// Scalar获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T ExecuteScalarForT<T>(string sql, object param) where T : class, new()
        {
            using (var conn = _Db.GetDbConnection())
            {
                return conn.ExecuteScalar<T>(sql, param);
            }
        }

        /// <summary>
        /// 带参数的存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static List<T> ExecutePro<T>(string proc, object param) where T : class, new()
        {
            using (var conn = _Db.GetDbConnection())
            {
                List<T> list = conn.Query<T>(proc,
                    param,
                    null,
                    true,
                    null,
                    CommandType.StoredProcedure).ToList();
                return list;
            }
        }


        /// <summary>
        /// 事务1 - 全SQL
        /// </summary>
        /// <param name="sqlarr">多条SQL</param>
        /// <param name="param">param</param>
        /// <returns></returns>
        public static int ExecuteTransaction(string[] sqlarr)
        {
            using (var conn = _Db.GetDbConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        foreach (var sql in sqlarr)
                        {
                            result += conn.Execute(sql, null, transaction);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 事务2 - 声明参数
        ///demo:
        ///dic.Add("Insert into Users values (@UserName, @Email, @Address)",
        ///        new { UserName = "jack", Email = "380234234@qq.com", Address = "上海" });
        /// </summary>
        /// <param name="Key">多条SQL</param>
        /// <param name="Value">param</param>
        /// <returns></returns>
        public static int ExecuteTransaction(Dictionary<string, object> dic)
        {
            using (var conn = _Db.GetDbConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int result = 0;
                        foreach (var sql in dic)
                        {
                            result += conn.Execute(sql.Key, sql.Value, transaction);
                        }

                        transaction.Commit();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
            }
        }
    }
}
