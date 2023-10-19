using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCodeFirstEF
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeDB")
        { }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Department> Departments { get; set;}
    }
}
