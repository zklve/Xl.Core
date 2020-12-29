using System;
using System.Collections.Generic;
using System.Text;
using Xl.Core.DomainModel.User.Output;
using Xl.Core.Repository.User;

namespace Xl.Core.ArchiveService.User
{
    public class UserService : IUserService
    {
        private IUserRepository repository;

        public UserService(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public UserInfo GetUser()
        {
            return new UserInfo
            {
                Name = "",
                Address =DateTime.Now.ToString()
            };
        }


        public Account GetAllInfoById(int Id)
        {
            return repository.GetAllInfoById(Id);
        }
    }
}
