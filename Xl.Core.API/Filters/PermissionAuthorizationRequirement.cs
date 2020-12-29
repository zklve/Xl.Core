using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xl.Core.API.Filters
{
    public class PermissionAuthorizationRequirement: IAuthorizationRequirement
    {
        public PermissionAuthorizationRequirement(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
