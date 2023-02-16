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
                    empEntity.Department = empModel.Department;
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
        public IEnumerable<EmpEntity> GetAllEmployee(long userId)
        {
            try
            {
                var result = userContext.EmpTable.Where(e => e.UserId == userId);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool UpdateEmp(long empId, long userId, EmpModel empModel)
        {
            try
            {
                var result = userContext.EmpTable.FirstOrDefault(e => e.EmpId == empId && e.UserId == userId);

                if (result != null)
                {
                    if (empModel.EmpName != null)
                    {
                        result.EmpName = empModel.EmpName;
                    }
                    if (empModel.ProfileImg != null)
                    {
                        result.ProfileImg = empModel.ProfileImg;
                    }
                    if (empModel.Gender != null)
                    {
                        result.Gender = empModel.Gender;
                    }
                    if (empModel.Department != null)
                    {
                        result.Department = empModel.Department;
                    }
                    if (empModel.Salary != null)
                    {
                        result.Salary = empModel.Salary;
                    }
                    if (empModel.StartDate  != null)
                    {
                        result.StartDate = empModel.StartDate;
                    }
                    if (empModel.Notes != null)
                    {
                        result.Notes = empModel.Notes;
                    }

                    //result.Edited = DateTime.Now;
                    userContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteEmp(long empId, long userId)
        {
            try
            {
                var result = userContext.EmpTable.FirstOrDefault(e => e.EmpId == empId && e.UserId == userId);

                if (result != null)
                {

                    userContext.EmpTable.Remove(result);
                    userContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
