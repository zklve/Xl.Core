using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.UniversalCommon.Configs
{
    /// <summary>
    /// DB配置信息
    /// </summary>
    public class DbConfig
    {
        /// <summary>
        /// 主机名或 IP 地址。
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 主机端口。
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 服务名。
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 登录用户名。
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录密码。
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 命令超时
        /// </summary>
        public int? CommandTimeout { get; set; }

        /// <summary>
        /// 连接寿命
        /// </summary>
        public int? ConnectionLifetime { get; set; }

    }
}
