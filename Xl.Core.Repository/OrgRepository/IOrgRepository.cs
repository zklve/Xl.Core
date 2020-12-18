using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.Repository.Org
{
    public interface IOrgRepository
    {
        /// <summary>
        /// 根据单个机构Id获取机构列表
        /// </summary>
        /// <returns></returns>
       List<object> GetOrgListByOrgId(long orgId);
    }
}
