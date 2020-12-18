using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.Repository.Company
{
    public class CompanyRepositoryImpl : ICompanyRepository
    {
        public List<object> GetCompanyByOrgIds(List<long> orgIds)
        {
            return new List<object>() {
                new { OrgId=1,OrgName="企业1"},
                new { OrgId=2,OrgName="企业2"},
                new { OrgId=3,OrgName="企业3"},
                new { OrgId=4,OrgName="企业4"},
                new { OrgId=5,OrgName="企业5"},
                new { OrgId=6,OrgName="企业6"},
                new { OrgId=7,OrgName="企业7"},
                new { OrgId=8,OrgName="企业8"}
            };
        }
    }
}
