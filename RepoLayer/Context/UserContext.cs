using Microsoft.EntityFrameworkCore;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        { }
        //Dbset create a table
        public DbSet<UserEntity> UserTable { get; set; }
        public DbSet<EmpEntity> EmpTable { get; set; }
    }
}
