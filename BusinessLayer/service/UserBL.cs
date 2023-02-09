using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iuserRL;

        public UserBL(IUserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }
        public UserEntity Registration(UserRegi userRegi)
        {
            try
             {
                return iuserRL.Registration(userRegi);
             }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string Login(LoginModel loginModel)
        {
            try
            {
                return iuserRL.Login(loginModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
