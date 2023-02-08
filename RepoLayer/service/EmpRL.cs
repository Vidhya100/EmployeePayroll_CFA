
using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.service
{
    public class EmpRL :IEmpRL
    {
        private readonly EmpContext empContext;

        public EmpRL(EmpContext empContext)
        {
            this.empContext = empContext;
        }

        public EmpEntity Registration(EmpoyeeRegi employeeRegi)
        {
            try
            {
                EmpEntity empEntity = new EmpEntity();  
                empEntity.EmpName = employeeRegi.EmpName;
                empEntity.ProfileImg = employeeRegi.ProfileImg;
                empEntity.Gender = employeeRegi.Gender;
                empEntity.Department = employeeRegi.Department;
                empEntity.Salary = employeeRegi.Salary; 
                empEntity.StartDate = employeeRegi.StartDate;
                empEntity.Email = employeeRegi.Email;
                empEntity.Password = employeeRegi.Password;
                empEntity.Notes = employeeRegi.Notes;

                empContext.EmpCFATable.Add(empEntity);

                int result = empContext.SaveChanges();

                if(result != 0)
                {
                    return empEntity;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public LoginModel Login(LoginModel loginModel)
        {
            try
            {
                var data = this.empContext.EmpCFATable.FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);
                //var dPass = ConvertoDecrypt(data.Password);
                if ( data != null)
                {
                    loginModel.Email = data.Email;
                    loginModel.Password = data.Password;
                    //var token = GenerateSecurityToken(data.Email, data.UserId);
                    //return token;
                    return loginModel;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
