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
        public delegate void SQLQueryDelegate();
        SQLQueryDelegate[] _query;
        public Form1()
        {
            InitializeComponent();

            //using (EmployeeContext db = new EmployeeContext())
            //{
            //    List<Department> departments = new List<Department>(){
            //        new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
            //        new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            //        new Department(){ Id = 3, Country = "France", City = "Paris" },
            //        new Department(){ Id = 4, Country = "UK", City = "London" }
            //    };

            //    List<Employee> employees = new List<Employee>(){
            //        new Employee(){ Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepartmentId = 2 },
            //        new Employee(){ Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepartmentId = 1 },
            //        new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepartmentId = 3 },
            //        new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepartmentId = 2 },
            //        new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepartmentId = 4 },
            //        new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepartmentId = 2 },
            //        new Employee() { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepartmentId = 4 }
            //    };

            //    db.Departments.AddRange(departments);
            //    db.Employees.AddRange(employees);
            //    db.SaveChanges();
            //}

            _query = new SQLQueryDelegate[4];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Работают в Украине, но не в Донецке");
            comboBox1.Items.Add("Вывести список стран без повторений");
            comboBox1.Items.Add("Топ 3 старше 25 лет");
            comboBox1.Items.Add("Выбрать из  Киева, возраст которых превышает 23 года");

            _query[0] = TheyWorkInUkraineButNotInDonetsk;
            _query[1] = ListOfCountriesWithoutRepetitions;
            _query[2] = Top3Over25YearsOld;
            _query[3] = KyivOver23YearsOld;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _query[comboBox1.SelectedIndex]();
        }
        private void TheyWorkInUkraineButNotInDonetsk()
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var e = db.Employees.Where(o=>o.Department.Country == "Ukraine" && 
                o.Department.City != "Donetsk").ToList();

                dataGridView1.DataSource = null;
                DataTable dt = new DataTable();

                dt.Columns.Add("ID");
                dt.Columns.Add("FirstName");
                dt.Columns.Add("LastName");

                foreach (var item in e)
                {
                    DataRow row = dt.NewRow();
                    row[0] = item.Id;
                    row[1] = item.FirstName;
                    row[2] = item.LastName;
                    dt.Rows.Add(row);
                }

                dataGridView1.DataSource = dt;
            }
        }
        private void ListOfCountriesWithoutRepetitions()
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var e = db.Departments.Select(o => o.Country).Distinct().ToList();

                dataGridView1.DataSource = null;
                DataTable dt = new DataTable();

                dt.Columns.Add("Country");

                foreach (var item in e)
                {
                    DataRow row = dt.NewRow();
                    row[0] = item;
                    dt.Rows.Add(row);
                }

                dataGridView1.DataSource = dt;
            }
        }
        private void Top3Over25YearsOld()
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var e = db.Employees.Where(o=>o.Age > 25).Take(3).ToList();

                dataGridView1.DataSource = null;
                DataTable dt = new DataTable();

                dt.Columns.Add("ID");
                dt.Columns.Add("FirstName");
                dt.Columns.Add("LastName");
                dt.Columns.Add("Age");

                foreach (var item in e)
                {
                    DataRow row = dt.NewRow();
                    row[0] = item.Id;
                    row[1] = item.FirstName;
                    row[2] = item.LastName;
                    row[3] = item.Age;
                    dt.Rows.Add(row);
                }

                dataGridView1.DataSource = dt;
            }
        }
        private void KyivOver23YearsOld()
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var e = db.Employees.Where(o => o.Age > 23 && o.Department.City == "Kyiv").ToList();

                dataGridView1.DataSource = null;
                DataTable dt = new DataTable();

                dt.Columns.Add("ID");
                dt.Columns.Add("FirstName");
                dt.Columns.Add("LastName");
                dt.Columns.Add("Age");

                foreach (var item in e)
                {
                    DataRow row = dt.NewRow();
                    row[0] = item.Id;
                    row[1] = item.FirstName;
                    row[2] = item.LastName;
                    row[3] = item.Age;
                    dt.Rows.Add(row);
                }

                dataGridView1.DataSource = dt;
            }
        }
    }
}
