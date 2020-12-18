using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Xl.Core.DbSession.DataBase
{
    /// <summary>
    /// 用于操作各种类型的数据库的接口。
    /// </summary>
    public interface IDb
    {
        /// <summary>
        /// 获取数据库连接,默认读写库
        /// </summary>
        /// <returns></returns>
        System.Data.IDbConnection GetDbConnection();

        /// <summary>
        /// 获取数据库连接 
        /// </summary>
        /// <param name="isReadOnly">是否只读 true 只读 false 读写</param>
        /// <returns></returns>
        System.Data.IDbConnection GetDbConnection(bool isReadOnly);


        /// <summary>
        /// 获取数据库连接 从池中获取。
        /// </summary>
        /// <returns></returns>
        System.Data.IDbConnection GetDbConnectionWithPool();


        /// <summary>
        /// 获取字段名，用于特定数据库对字段名关键字的转换。
        /// </summary>
        /// <param name="columnCode"></param>
        /// <returns></returns>
        string GetColumnName(string columnCode);

        /// <summary>
        /// 获取一个新的操作大对象数据类型的接口。
        /// </summary>
        /// <param name="parameterName">参数名。</param>
        /// <param name="value">值。</param>
        /// <returns></returns>
        System.Data.IDbDataParameter GetDbDataParameter(string parameterName, object value);

        /// <summary>
        /// 获取操作大对象数据类型时 SQL 语句中指定的参数值的名称。
        /// </summary>
        /// <param name="parameterName">参数名。</param>
        /// <returns></returns>
        string GetDbDataParameterValueName(string parameterName);

        /// <summary>
        /// 获取操作日期数据类型时 SQL 语句中指定的参数值的名称。
        /// </summary>
        /// <param name="parameterName">参数名。</param>
        /// <returns></returns>
        string GetDbDataParameterValueNameByDateTime(string parameterName);

        

        /// <summary>
        /// 确定指定的数据表是否已创建。
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        bool TableIsExist(string tableName);

        /// <summary>
        /// 获取使用聚合函数 AVG 计算某列平均值的 SQL 字段写法。
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        string GetAvgColumn(string columnName);

        /// <summary>
        /// 获取 Order By 排序字段的 SQL 写法（参数排序的列如果可能存在空值则应该调用此方法），并按空值(null)为最小值的规则进行排序。
        /// </summary>
        /// <param name="columnName">字段名。</param>
        /// <param name="isDesc">是否按照从大到小的顺序排列。</param>
        /// <returns></returns>
        string GetOrderByColumn(string columnName, bool isDesc);

        /// <summary>
        /// 分页显示第1页的数据。
        /// </summary>
        /// <param name="dbConnection">已打开的数据库连接</param>
        /// <param name="pageSize">每页显示的数据数量</param>
        /// <param name="selectColumns">需要输出的字段</param>
        /// <param name="tableNames">表名</param>
        /// <param name="where">查询条件</param>
        /// <param name="order_Tablename">含有表名的排序条件</param>
        /// <returns></returns>
        System.Data.IDataReader GetDataReader(DbConnection dbConnection, int pageSize, string selectColumns, string tableNames, string where, string order_Tablename);

        /// <summary>
        /// 分页显示从第2页至倒数第2页的数据。
        /// </summary>
        /// <param name="dbConnection">已打开的数据库连接</param>
        /// <param name="pageSize">每页显示的数据数量</param>
        /// <param name="pageNum">获取第几页的数据</param>
        /// <param name="selectColumns">需要输出的字段</param>
        /// <param name="tableNames">表名</param>
        /// <param name="where">查询条件</param>
        /// <param name="order_Tablename">含有表名的排序条件</param>
        /// <param name="order_Reverse">倒序排序条件</param>
        /// <param name="order">排序条件</param>
        /// <returns></returns>
        System.Data.IDataReader GetDataReader(DbConnection dbConnection, int pageSize, int pageNum, string selectColumns, string tableNames, string where, string order_Tablename, string order_Reverse, string order);

        /// <summary>
        /// 分页显示最后一页的数据。
        /// </summary>
        /// <param name="dbConnection">已打开的数据库连接</param>
        /// <param name="pageSize">每页显示的数据数量</param>
        /// <param name="recordsetCount">数据总数量</param>
        /// <param name="selectColumns">需要输出的字段</param>
        /// <param name="tableNames">表名</param>
        /// <param name="where">查询条件</param>
        /// <param name="order_TablenameReverse">含有表名的倒序排序条件</param>
        /// <param name="order">排序条件</param>
        /// <returns></returns>
        System.Data.IDataReader GetDataReader(DbConnection dbConnection, int pageSize, int recordsetCount, string selectColumns, string tableNames, string where, string order_TablenameReverse, string order);

        /// <summary>
        /// 分页显示第1页的数据。
        /// </summary>
        /// <param name="dbConnection">已打开的数据库连接</param>
        /// <param name="pageSize">每页显示的数据数量</param>
        /// <param name="selectColumns">需要输出的字段</param>
        /// <param name="tableNames">表名</param>
        /// <param name="where">查询条件</param>
        /// <param name="order_Tablename">含有表名的排序条件</param>
        /// <param name="commandTimeout">在终止执行命令的尝试并生成错误之前的等待时间。-1 表示使用默认值 30 秒。</param>
        /// <param name="dataParameters">与 Command 对象有关的参数及其到 DataSet 列的映射。如无参数可为 null。</param>
        /// <returns></returns>
        System.Data.IDataReader GetDataReader(DbConnection dbConnection, int pageSize, string selectColumns, string tableNames, string where, string order_Tablename, int commandTimeout, params System.Data.IDbDataParameter[] dataParameters);

    }
}
