using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.service
{
    public class EmpBL : IEmpBL
    {
        private readonly IEmpRL iempRL;

        public EmpBL(IEmpRL iempRL)
        {
            this.iempRL = iempRL;
        }
        public EmpEntity Registration(EmpoyeeRegi employeeRegi)
        {
            try
             {
                return iempRL.Registration(employeeRegi);
             }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
