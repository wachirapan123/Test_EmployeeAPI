using System.Globalization;
using EmployeeApi.Domain;

namespace EmployeeApi.Infrastructure
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Employees.Any()) return;

            var format = "dd-MMM-yy"; 
            var culture = CultureInfo.InvariantCulture;

 
            var rawEmployees = new List<(int EmpNo, string First, string Last, string Designation, string Hire, decimal Salary, string Comm, int Dept)>
            {
                (1001, "STEFAN","SALVATORE", "BUSSINESS ANALYST",  "17-Nov-97", 50000, "-",   40),
                (1002, "DIANA", "LORRENCE",  "TECHNIAL ARCHITECT", "01-May-00", 70000, "-",   10),
                (1003, "JAMES", "MADINSAON", "MANAGER",            "19-Jun-88", 80400, "-",   40),
                (1004, "JONES", "NICK",      "HR ANALYST",         "02-Jan-03", 47000, "-",   30),
                (1005, "LUCY",  "GELLLER",   "HR ASSOCIATE",       "13-Jul-08", 35000, "200", 30),
                (1006, "ISAAC", "STEFAN",    "TRAINEE",            "13-Dec-15", 20000, "-",   40),
                (1007, "JOHN",  "SMITH",     "CLERK",              "17-Dec-05", 12000, "-",   10),
                (1008, "NANCY", "GILLBERT",  "SALESMAN",           "20-Feb-81", 1600,  "300", 10)
            };

            var employees = rawEmployees.Select(e => new Employee
            {
                EmpNo = e.EmpNo,
                FirstName = e.First,
                LastName = e.Last,
                Designation = e.Designation,
                HireDate = DateTime.ParseExact(e.Hire, format, culture),
                Salary = e.Salary,
                Comm = e.Comm == "-" ? null : decimal.Parse(e.Comm),
                DeptNo = e.Dept
            }).ToList();

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
