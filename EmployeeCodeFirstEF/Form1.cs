using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeCodeFirstEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (EmployeeContext db = new EmployeeContext())
            {
                List<Department> departments = new List<Department>(){
                    new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                    new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                    new Department(){ Id = 3, Country = "France", City = "Paris" },
                    new Department(){ Id = 4, Country = "UK", City = "London" }
                };

                List<Employee> employees = new List<Employee>(){
                    new Employee(){ Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepartmentId = 2 },
                    new Employee(){ Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepartmentId = 1 },
                    new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepartmentId = 3 },
                    new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepartmentId = 2 },
                    new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepartmentId = 4 },
                    new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepartmentId = 2 },
                    new Employee() { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepartmentId = 4 }
                };

                db.Departments.AddRange(departments);
                db.Employees.AddRange(employees);
                db.SaveChanges();
            }
        }
    }
}
