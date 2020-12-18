using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.Repository.Company;

namespace XL.Core.Application.CompanyApplication
{
    public class CompanyApplicationImpl : ICompanyApplication
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyApplicationImpl(ICompanyRepository companyRepository)
        {
            this._companyRepository = companyRepository;
        }

        public List<object> GetCompanyByOrgIds(List<long> orgIds)
        {
            return _companyRepository.GetCompanyByOrgIds(orgIds);
        }

    }
}
