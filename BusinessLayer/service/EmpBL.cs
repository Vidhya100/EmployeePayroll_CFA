using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.service
{
    public class EmpBL: IEmpBL
    {
        private readonly IEmpRL iempRL;

        public EmpBL(IEmpRL iempRL)
        {
            this.iempRL = iempRL;
        }

        public EmpEntity AddEmp(EmpModel empModel, long userId)
        {
            try
            {
                return iempRL.AddEmp(empModel, userId);
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
                return iempRL.GetAllEmployee(userId);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public bool UpdateEmp(long empId, long userId, EmpModel empModel)
        {
            try
            {
                return iempRL.UpdateEmp(empId, userId, empModel);
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
