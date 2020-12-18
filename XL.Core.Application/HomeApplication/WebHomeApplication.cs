using System;
using System.Collections.Generic;
using System.Text;

namespace XL.Core.Application.HomeApplication
{
    public class WebHomeApplication : IHomeApplication
    {
        public string HomeType { get; } = "APP";

        public WebHomeApplication()
        {

        }

        public object GetHomeData(object data)
        {
            throw new NotImplementedException();
        }
    }
}
