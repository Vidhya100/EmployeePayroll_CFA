using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmpBL
    {
        public EmpEntity AddEmp(EmpModel empModel, long userId);
    }
}
