using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.Repository.User;

namespace Xl.Core.ArchiveService.User
{
    public class UserAggregate 
    {

        public static IUserRepositorycs _userRepository;

        public string AccountCode { get; set; }

        public string ExpireDate { get; set; }

        public bool IsSuperAdmin { get; set; }

        public UserAggregate(IUserRepositorycs repository)
        {

        }

        public static void RegisterUserRepository(IUserRepositorycs repository)
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
