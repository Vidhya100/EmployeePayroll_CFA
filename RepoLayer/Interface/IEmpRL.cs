using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IEmpRL
    {
        public EmpEntity Registration(EmpoyeeRegi employeeRegi);
        public LoginModel Login(LoginModel loginModel);

    }
}
