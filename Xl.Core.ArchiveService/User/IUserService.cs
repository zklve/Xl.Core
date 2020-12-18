using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.DomainModel.User.Output;

namespace Xl.Core.ArchiveService.User
{
    public interface IUserService
    {
        UserInfo GetUser();

        /// <summary>
        /// 根据账号Id获取所有信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Account GetAllInfoById(int Id);
    }
}
