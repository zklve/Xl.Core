using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.DbSession.DataBase;
using Xl.Core.DbSession.Helper;

namespace Xl.Core.Repository.Base
{
    public class BaseRepo
    {
        public BaseRepo(IDb db)
        {
            if (DapperHelper._Db == null)
            {
                DapperHelper._Db = db;
            }
        }
    }
}
