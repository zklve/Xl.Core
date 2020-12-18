using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.Repository.Company
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// 通过OrgId获取企业列表
        /// </summary>
        /// <param name="orgIds"></param>
        /// <returns></returns>
        List<object> GetCompanyByOrgIds(List<long> orgIds);
    }
}
