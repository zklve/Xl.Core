using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.Repository.Org;

namespace XL.Core.Application.OrgApplication
{
    public interface IOrgApplication
    {
        /// <summary>
        /// 根据单个机构Id获取机构列表
        /// </summary>
        /// <returns></returns>
        List<object> GetOrgListByOrgId(long orgId);

        /// <summary>
        /// 获取机构下企业数量
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        List<object> GetOrgCompanyCount(long orgId);
    }
}
