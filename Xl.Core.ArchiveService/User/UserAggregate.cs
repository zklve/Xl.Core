using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.Repository.User;

namespace Xl.Core.ArchiveService.User
{
    public class UserAggregate 
    {

        public static IUserRepository _userRepository;

        public string AccountCode { get; set; }

        public string ExpireDate { get; set; }

        public bool IsSuperAdmin { get; set; }

        public UserAggregate(IUserRepository repository)
        {

        }

        public static void RegisterUserRepository(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public void Save()
        {

        }

        public void GetOneById()
        {

        }

    }
}
