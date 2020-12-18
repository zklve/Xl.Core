using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XL.Core.Application.CompanyApplication;

namespace XL.Core.Application.OrgApplication
{
    public class OrgApplicationImpl : IOrgApplication
    {
        private readonly IOrgApplication _orgApplication;
        private readonly ICompanyApplication _companyApplication;


        public OrgApplicationImpl(IOrgApplication orgApplication, ICompanyApplication companyApplication)
        {
            this._orgApplication = orgApplication;
            this._companyApplication = companyApplication;
        }

        public ICompanyApplication CompanyApplication { get; }

        public List<object> GetOrgCompanyCount(long orgId)
        {
            var orgList = _orgApplication.GetOrgCompanyCount(orgId);
            var companyList = _companyApplication.GetCompanyByOrgIds(orgList.Select(x => long.Parse(x.ToString())).ToList());
            return companyList;
        }

        public List<object> GetOrgListByOrgId(long orgId)
        {
            throw new NotImplementedException();
        }
    }
}
