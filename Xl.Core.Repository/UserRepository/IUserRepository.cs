﻿using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.DomainModel.User.Output;
using Xl.Core.Repository.Base;

namespace Xl.Core.Repository.User
{
    public interface IUserRepository 
    {
        string GetUserName(string accountCode);

        Account GetAllInfoById(int Id);

        void Save();

    }
}
