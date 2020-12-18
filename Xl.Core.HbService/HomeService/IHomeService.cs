using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.HbService.HomeService
{
    public interface IHomeService
    {
        /// <summary>
        /// 获取App首页信息
        /// </summary>
        /// <returns></returns>
        object GetAppHomeData();
    }
}
