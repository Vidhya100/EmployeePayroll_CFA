using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IEmpRL
    {
        public EmpEntity AddEmp(EmpModel empModel, long userId);
    }
}
