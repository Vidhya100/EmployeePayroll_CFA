using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRL
    {
        public UserEntity Registration(UserRegi userRegi);
        public string Login(LoginModel loginModel);
        
    }
}
