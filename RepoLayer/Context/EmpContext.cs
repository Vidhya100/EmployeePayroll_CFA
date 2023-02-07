using Microsoft.EntityFrameworkCore;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Context
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions options) : base(options)
        { }
        //Dbset create a table
        public DbSet<EmpEntity> EmpCFATable { get; set; }
    }
}
