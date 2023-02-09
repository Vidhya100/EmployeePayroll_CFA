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
    public class EmpRL : IEmpRL
    {
        private readonly UserContext userContext;

        public EmpRL(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public EmpEntity AddEmp(EmpModel empModel, long userId)
        {
            try
            {

                var result = userContext.EmpTable.Where(x => x.UserId == userId);

                if (result != null)
                {
                    EmpEntity empEntity = new EmpEntity();
                    empEntity.EmpName = empModel.EmpName;
                    empEntity.ProfileImg = empModel.ProfileImg;
                    empEntity.Gender = empModel.Gender;
                    empEntity.Email = empModel.Email;
                    empEntity.Department = empModel.Department;
                    empEntity.Password = empModel.Password;
                    empEntity.Salary = empModel.Salary;
                    empEntity.StartDate = empModel.StartDate;
                    empEntity.Notes = empModel.Notes;
                    empEntity.UserId = userId;

                    userContext.EmpTable.Add(empEntity);

                    userContext.SaveChanges();
                    return empEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
