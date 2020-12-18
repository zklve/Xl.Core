using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.Repository.Org;

namespace XL.Core.Application.HomeApplication
{
    public class AppHomeApplicationImpl : IHomeApplication
    {
        private readonly IOrgRepository _orgRepository;

        public string HomeType { get; } = "WEB";

        public AppHomeApplicationImpl(IOrgRepository orgRepository)
        {
            this._orgRepository = orgRepository;
        }

        /// <summary>
        /// 获取App首页数据
        /// </summary>
        /// <returns></returns>
        public object GetHomeData()
        {
            _orgRepository.GetOrgListByOrgId();
            return new object();
        }
    }
}
