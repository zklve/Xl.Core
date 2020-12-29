using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.DbSession;
using Xl.Core.DbSession.DataBase;
using Xl.Core.DbSession.Helper;
using Xl.Core.DomainModel.User.Output;
using Xl.Core.Repository.Base;

namespace Xl.Core.Repository.User
{
    public class UserRepository : BaseRepo, IUserRepository
    {

        public string GetUserName(string accountCode)
        {
            return "";
        }

        public Account GetAllInfoById(int Id)
        {
            string sql = " select *  from account where accountid =@id ";
            return DapperHelper.QueryFirst<Account>(sql, new { id= Id });
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
