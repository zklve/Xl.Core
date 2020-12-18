using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.DomainModel.User.Output
{
    public class Account
    {
        public int AccountID { get; set; }

        public string AccountCode { get; set; }
        public string UserName { get; set; }
        public string EmailName { get; set; }
        public string PhoneNum { get; set; }
        public string DepartMent { get; set; }
        public string ManageArea { get; set; }
        public string SuperManage { get; set; }
        public string ModifyPass { get; set; }
        public string AccountLock { get; set; }
        public string UserPassWord { get; set; }
        public string BakContent { get; set; }
        public string XMLConfig { get; set; }
        public string SystemName { get; set; }

        public int IsEnableMessage { get; set; }
        public long LastModifyPwdTime { get; set; }

    }
}
