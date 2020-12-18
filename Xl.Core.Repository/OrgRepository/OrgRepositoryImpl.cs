using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.Repository.Org
{
    public class OrgRepositoryImpl : IOrgRepository
    {
        public List<object> GetOrgListByOrgId(long orgId)
        {
            return new List<object>() { 
                new { OrgId=1,OrgName="江苏1"},
                new { OrgId=2,OrgName="江苏2"},
                new { OrgId=3,OrgName="江苏3"},
                new { OrgId=4,OrgName="江苏4"},
                new { OrgId=5,OrgName="江苏5"},
                new { OrgId=6,OrgName="江苏6"},
                new { OrgId=7,OrgName="江苏7"},
                new { OrgId=8,OrgName="江苏8"}
            };

        }
    }
}
